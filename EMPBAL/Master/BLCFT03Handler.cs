using EMPDAL;
using EMPMAL;
using Microsoft.AspNetCore.Http;
using ServiceStack.OrmLite;
using System.Data;

namespace EMPBAL
{
    public class BLCFT03Handler
    {
        CFT03 objT03 = null;
        public void PreSave(DTOT03 objDTOT03)
        {
            objT03 = new CFT03();
            objT03.T03F01 = objDTOT03.T03F01;
            objT03.T03F02 = objDTOT03.T03F02;
            objT03.T03F03 = objDTOT03.T03F03;
            objT03.T03F04 = objDTOT03.T03F04;
            objT03.T03F05 = objDTOT03.T03F05;
            objT03.T03F06 = objDTOT03.T03F06;
            objT03.T03F07 = objDTOT03.T03F07;
            objT03.T03F08 = objDTOT03.T03F08;
            objT03.T03F09 = objDTOT03.T03F09;
            objT03.T03F10 = objDTOT03.T03F10;
            objT03.T03F11 = objDTOT03.T03F11;

            if (objT03.T03F10 <= 250000)
            {
                objT03.T03F11 = 0;
            }
            else if (objT03.T03F10 >= 250001 && objT03.T03F10 <= 500000)
            {
                objT03.T03F11 = ((objT03.T03F10 * 5) / 100);
            }
            else if (objT03.T03F10 >= 500001 && objT03.T03F10 <= 1000000)
            {
                objT03.T03F11 = (((objT03.T03F10 * 20) / 100 ) + 12500);
            }
            else if (objT03.T03F10 > 1000000)
            {
                objT03.T03F11 = (((objT03.T03F10 * 30) / 100) + 20000);
            }
        }
        public Response GetEmployee()
        {
            Response objResponse = new Response();
            List<CFT03> lstT03 = new List<CFT03>();
            DBCFT03Context objContext = new DBCFT03Context();
            lstT03 = objContext.GetEmployee();

            if (lstT03 != null && lstT03.Any())
            {
                objResponse.Status = StatusCodes.Status200OK;
                objResponse.Result = lstT03;
            }
            else
            {
                objResponse.Status = StatusCodes.Status404NotFound;
                objResponse.Result = new List<string>(0);
            }
            return objResponse;
        }

        public Response Insert()
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using(IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT03.T03F01 == 0)
                    {
                        db.Insert(objT03);
                        objResponse.Message = "Recored Insert Sucessfully";
                    }
                    else
                    {
                        objResponse.Message = "Record AllReady Exist";
                    }
                    Trans.Commit();
                }
            }
            objResponse.Status = StatusCodes.Status200OK;
            return objResponse;
        }

        public Response Update()
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using(IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT03.T03F01 != 0)
                    {
                        db.Update(objT03);
                        objResponse.Message = "Recored Update Sussecefully";
                    }
                    else
                    {
                        objResponse.Message = "Recored Not Exist";
                    }
                    Trans.Commit();
                }
            }
            objResponse.Status = StatusCodes.Status200OK;
            return objResponse;
        }

        public Response Delete(int EmployeeId)
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (EmployeeId != 0)
                    {
                        db.DeleteById<CFT03>(EmployeeId);
                        objResponse.Message = "Employee Delete Sucessfully";
                    }
                    else
                    {
                        objResponse.Message = "EmployeeId Not Found";
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }
    }
}
