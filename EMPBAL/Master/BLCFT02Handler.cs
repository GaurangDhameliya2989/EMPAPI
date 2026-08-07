using EMPDAL;
using EMPMAL;
using Microsoft.AspNetCore.Http;
using ServiceStack.OrmLite;
using System.Data;

namespace EMPBAL
{
    public class BLCFT02Handler
    {
        CFT02 objT02 = null; //Object Of POCO Class Initialize Null
        public void Presave(DTOT02 objDTOT02)
        {
            objT02 = new CFT02(); //Initialize The Object Of POCO Class Empty
            objT02.T02F01 = objDTOT02.T02F01; //Set The Value of DTO Class (By User) in POCO Class
            objT02.T02F02 = objDTOT02.T02F02; //Set The Value of DTO Class (By User) in POCO Class
        }
        public Response GetDesignation()
        {
            Response objResponse = new Response();
            List<CFT02> lstT02 = new List<CFT02>();
            DBCFT02Context dbContext = new DBCFT02Context();
            lstT02 = dbContext.GetDesignation();

            if (lstT02 != null && lstT02.Any())
            {
                objResponse.Status = StatusCodes.Status200OK;
                objResponse.Result = lstT02;
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
            Response objresponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT02.T02F01 == 0)
                    {
                        db.Insert(objT02);
                    }
                    else
                    {
                        objresponse.Message = "Data is AllReady Exist";
                    }
                    Trans.Commit();
                }
            }
            objresponse.Status = StatusCodes.Status200OK;
            return objresponse;
        }
        public Response Update()
        {
            Response objresponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (objT02.T02F01 != 0)
                    {
                        db.Update(objT02);
                    }
                    else
                    {
                        objresponse.Message = "Recored Not Exist";
                    }
                    Trans.Commit();
                }
            }
            objresponse.Status = StatusCodes.Status200OK;
            return objresponse;
        }

        public Response Dlete(int DesignationId)
        {
            Response objResponse = new Response();
            using (var db = new MySqlOrmLite().Open())
            {
                using (IDbTransaction Trans = db.OpenTransaction())
                {
                    if (DesignationId != 0)
                    {
                        db.DeleteById<CFT02>(DesignationId);
                        objResponse.Message = "Designation Delete Sucessfully";
                    }
                    else
                    {
                        objResponse.Message = "DesignationId Not Found";
                    }
                    Trans.Commit();
                }
            }
            return objResponse;
        }
        
    }
}
