<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Travelling.Job._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>悦悦定时任务系统</title>
    <link type="text/css" href="styles/jobtask.css" rel="stylesheet" />
    <script type="text/javascript">
        window.onload = function () {
            setInterval("reload()",10000);
        }

        function reload() {
            window.location.href = "/default.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="/default.aspx">首页</a>
            <a href="/setting.aspx">管理</a>
        </div>
    <div>
        <%if (JobTasks.Count == 0)
          { 
            %>
           <div>没有任务</div>
          <%
          }
          else
          {
          %>
        <table class="gridtable">
            <tr>
                <th>任务名称</th>
                <th>任务方法</th>
                <th>Group名字</th>
                <th>CRON表达式</th>
                <th>下次执行时间</th>
                <th>状态</th>
            </tr>
            
            <%foreach (var job in JobTasks)
              { 
                %>
            <tr>
                <td><%=job.JobName %></td>
                <td><%=job.JobMethodName %></td>
                <td><%=job.GroupName %></td>
                <td><%=job.CronExpr %></td>
                <td><%=GetNextRunTime(job) %></td>
                <td><%=job.State==1?"有效":"无效" %></td>
            </tr>
            <%
              } %>
        </table>
        <%} %>
    </div>
    </form>
</body>
</html>
