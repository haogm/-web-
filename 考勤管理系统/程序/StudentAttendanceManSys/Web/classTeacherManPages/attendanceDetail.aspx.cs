﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utility.Global;
using BLL;
using System.Data;
using Utility;

namespace Web.classTeacherManPages
{
    public partial class attendanceDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void bind()
        {
            string classId = Request.QueryString["classId"];

            string week = Request.QueryString["week"];

            CommonBLL commBLL = new CommonBLL();

            DataTable dt = commBLL.getWeekDetailAttendaceRate(week[1].ToString(), classId,true);

            AspNetPager1.RecordCount = dt.Rows.Count;

            int from = (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize + 1;
            int to = from + AspNetPager1.PageSize - 1 > AspNetPager1.RecordCount ? AspNetPager1.RecordCount : from + AspNetPager1.PageSize - 1;

            GridView1.DataSource = PageUtil.getPaged(dt, from, to);
            GridView1.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            bind();
        }
    }
}