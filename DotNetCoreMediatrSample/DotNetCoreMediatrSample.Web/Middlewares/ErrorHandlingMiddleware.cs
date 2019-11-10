using System;
using System.Net;
using System.Threading.Tasks;
using DotNetCoreMediatrSample.Domain.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DotNetCoreMediatrSample.Web.Middlewares
{
    /// <summary>
    /// 基底の例外処理を行うミドルウェアです
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// ロジック内で発生した例外に応じて処理を行います
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="ex">Exception</param>
        /// <returns>Task</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // 例外に応じてHTTPステータスコードを設定します
            var code = HttpStatusCode.InternalServerError;
            if (ex is DomainException) code = HttpStatusCode.BadRequest;

            // エラーメッセージを設定します
            var result = JsonConvert.SerializeObject(new {error = ex.Message});
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(result);
        }
    }
}