using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;

namespace Business
{
    public static class UserBusiness
    {
        /// <summary>
        /// 判断账号是否存在（执行sql命令实现）
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool IsExistUserID(string userid)
        {
            string cmdText = "select * from tb_user where userid=@Userid";
            string[] paramNames = { "@Userid" };
            object[] paramValues = { userid };
            object obj=BookDA.ExecuteSqlCommand2(cmdText,CommandType.Text,paramNames,paramValues);
            return (obj!=null);
        }

        /// <summary>
        ///  判断账号是否存在(调用存储过程实现)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool IsExistUserID2(string userid)
        {
            string cmdText = "isExistID";
            string[] paramNames = { "@userid" };
            object[] paramValues = { userid };
            object obj;
           BookDA.ExcuteSqlCommand(cmdText, CommandType.StoredProcedure, paramNames, paramValues,out obj,SqlDbType.Bit);
            return (bool)obj;
        }

        /// <summary>
        /// 判断账号是否锁定
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static bool IsLockedUserID(string userid)
        {
            string cmdText = "select isLocked from tb_user where userid=@Userid";
            string[] paramNames = { "@Userid" };
            object[] paramValues = { userid };
            object obj = BookDA.ExecuteSqlCommand2(cmdText, CommandType.Text, paramNames, paramValues);
            return (bool)obj;
        }
        /// <summary>
        /// 判断账号密码是否正确
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool IsRightPwd(string userid, string pwd)
        {
            string cmdText = "select * from tb_user where userid=@Userid and pwd=@Pwd";
            string[] paramNames = { "@Userid", "@Pwd"};
            object[] paramValues = { userid, pwd };
            object obj = BookDA.ExecuteSqlCommand2(cmdText, CommandType.Text, paramNames, paramValues);
            return (obj != null);
        }

        public static UserEntity GetUserById(string id)
        {
            string cmdText = "select * from tb_user where UserId=@UserId";
            string[] paramNames = { "@UserId" };
            object[] paramValues = { id };
            DataTable dt = BookDA.GetDataTable(cmdText, CommandType.Text, paramNames, paramValues);
            if (dt.Rows.Count == 0)
                return null;
            return new UserEntity
            {
                UserId = dt.Rows[0]["UserId"].ToString(),
                Pwd = dt.Rows[0]["Pwd"].ToString(),
                UserName = dt.Rows[0]["UserName"].ToString(),
                LoginTime = (DateTime)dt.Rows[0]["LoginTime"],
                LastLoginTime = (DateTime)dt.Rows[0]["LastLoginTime"],
                LoginCounts = (int)dt.Rows[0]["LoginCounts"],
                ErrorCounts = (int)dt.Rows[0]["ErrorCounts"],
                IsLocked = (bool)dt.Rows[0]["IsLocked"]
            };
        }

        public static bool InsertUserInfo(UserEntity user)
        {
            string cmdText = "insert into tb_user (UserName,Pwd,LastLoginTime,LoginTime,LoginCounts,ErrorCounts,IsLocked) values (@UserName,@Pwd,@LastLoginTime,@LoginTime,@LoginCounts,@ErrorCounts,@IsLocked)";
            string[] paramNames = { "@UserName", "@Pwd", "@LastLoginTime", "@LoginTime", "@LoginCounts", "@ErrorCounts", "@IsLocked" };
            object[] paramValues = { user.UserName, user.Pwd, user.LastLoginTime, user.LoginTime, user.LoginCounts, user.ErrorCounts, user.IsLocked };
            return BookDA.ExcuteSqlCommand(cmdText,CommandType.Text, paramNames, paramValues)>0?true:false;
        }
    }
}
