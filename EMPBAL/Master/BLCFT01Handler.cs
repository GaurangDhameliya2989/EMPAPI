using EMPDAL;
using EMPMAL;
using Microsoft.AspNetCore.Http;
using ServiceStack.OrmLite;
using System.Data;

namespace EMPBAL
{
    public class BLCFT01Handler
    {
        CFT01 objT01 = null; //object of poco class initialize null
        public void PreSave(DTOT01 objDTOT01)
        {
            objT01 = new CFT01(); //initialize the object of poco class empty
            objT01.T01F01 = objDTOT01.T01F01; //Set The Value of DTO Class (By User) in POCO Class
            objT01.T01F02 = objDTOT01.T01F02; //Set The Value of DTO Class (By User) in POCO Class
        }
        public Response GetDepartment()
        {
            Response objResponse = new Response();
            List<CFT01> lstT01 = new List<CFT01>();
            DBCFT01Context dbcontext = new DBCFT01Context();
            lstT01 = dbcontext.GetDepartment();

            if (lstT01 != null && lstT01.Any())
            {
                objResponse.Status = StatusCodes.Status200OK;
                //objResponse.Message = SuccessMessage.S0001;
                objResponse.Result = lstT01;
            }
            else
            {
                objResponse.Status = StatusCodes.Status404NotFound;
                //objResponse.Message = ErrorMessage.E0002;
                objResponse.Result = new List<string>(0);
            }
            return objResponse;
        }
        public Response InsertUpdate()
        {
            Response objResponse = new Response();
            int departmentId = 0;
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {

                    try
                    {
                        if (objT01.T01F01 == 0)
                        {
                            departmentId = (int)db.Insert(objT01, selectIdentity: true);
                        }
                        else
                        {
                            departmentId = objT01.T01F01;
                            db.Update(objT01);
                        }

                        Trans.Commit();
                    }
                    catch
                    {
                        Trans.Rollback();
                        throw;
                    }
                }
            }
            objResponse.Status = StatusCodes.Status200OK;
            objResponse.Result = departmentId;
            return objResponse;
        }

        public Response Update()
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT01.T01F01 != 0)
                    {
                        db.Update(objT01);
                    }
                    else
                    {
                        objResponse.Message = "Record Is Not Exist";
                    }
                    Trans.Commit();
                }
            }
            objResponse.Status = StatusCodes.Status200OK;
            return objResponse;
        }

        public Response DeleteDepartment(int DepartmentId)
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction trans = db.OpenTransaction())
                {
                    if (DepartmentId != 0)
                    {
                        db.DeleteById<CFT01>(DepartmentId);
                        objResponse.Message = "Recored Delete SucessFullt";
                    }
                    else
                    {
                        objResponse.Message = "DepartmentId Is Not Found";
                    }
                    trans.Commit();

                }
            }
            return objResponse;
        }
    }
}
