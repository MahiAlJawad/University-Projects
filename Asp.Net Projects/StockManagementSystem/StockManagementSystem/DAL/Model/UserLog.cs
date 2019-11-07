using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class UserLog
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }

        public UserLog(int id, string username, string startTime, string endTime)
        {
            Id = id;
            Username = username;
            StartTime = startTime;
            EndTime = endTime == "" ? "Active or Terminated" : endTime;
        }
    }
}