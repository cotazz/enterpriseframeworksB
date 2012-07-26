<%@ Page Language="C#" %>
<%
Response.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
%>