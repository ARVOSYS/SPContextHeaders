using Microsoft.SharePoint.Client;
using System;
using System.Net;

namespace SPContextHeaders
{
    public class ContextHeaders
    {
        private static EventHandler<WebRequestEventArgs> ExecutingWebRequestHandlerInstance { get; set; }
        private static WebHeaderCollection RequestHeaders { get; set; }

        public static WebHeaderCollection GetHeaders(ClientContext ctx)
        {
            ExecutingWebRequestHandlerInstance = new EventHandler<WebRequestEventArgs>(ExecutingWebRequestHandler);
            ctx.ExecutingWebRequest += ExecutingWebRequestHandlerInstance;
            Web web = ctx.Web;
            ctx.Load(web, w => w.Title);
            ctx.ExecuteQuery();
            return RequestHeaders;
        }

        private static void ExecutingWebRequestHandler(object sender, WebRequestEventArgs e)
        {
            RequestHeaders = e.WebRequestExecutor.RequestHeaders;
            (sender as ClientContext).ExecutingWebRequest -= ExecutingWebRequestHandlerInstance;
        }
    }
}
