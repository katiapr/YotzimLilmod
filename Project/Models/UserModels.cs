using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;


namespace YotzimLilmod.Models
{
    public class UserModels
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "Please Provide Username", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please provide password", AllowEmptyStrings = false)]
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserCity { get; set; }
        public string userEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public bool isTeacher { get; set; }
        public bool isCoordinator { get; set; }
        public bool isScholarship { get; set; }
        public int UserIDNumber { get; set; }
        public DateTime UserLastUpdate { get; set; }

        public UserModels()
        {

        }
        public bool IsValid(string _username, string _password)
        {
            
            //using (var cn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename" +
            //  @"='C:\Tutorials\1 - Creating a custom user login form\Creating " +
            //  @"a custom user login form\App_Data\Database1.mdf';Integrated Security=True"))
            //{
            //    string _sql = @"SELECT [Username] FROM [dbo].[System_Users] " +
            //           @"WHERE [Username] = @u AND [Password] = @p";
            //    var cmd = new SqlCommand(_sql, cn);
            //    cmd.Parameters
            //        .Add(new SqlParameter("@u", SqlDbType.NVarChar))
            //        .Value = _username;
            //    cmd.Parameters
            //        .Add(new SqlParameter("@p", SqlDbType.NVarChar))
            //        .Value = Helpers.SHA1.Encode(_password);
            //    cn.Open();
            //    var reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        reader.Dispose();
            //        cmd.Dispose();
            //        return true;
            //    }
            //    else
            //    {
            //        reader.Dispose();
            //        cmd.Dispose();
            //        return false;
            //    }
            //}
            //var user = 
            return true;
        }
    }
}
