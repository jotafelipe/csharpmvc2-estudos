using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Routing;

namespace System.Web.Mvc.Html {

    /// <summary>
    /// 
    /// </summary>
    public static class LabelExtensions {

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelFor<TModel, TValue>(
                this HtmlHelper<TModel> html,
                Expression<Func<TModel, TValue>> expression,
                object htmlAttributes) {
            return LabelFor(html, expression,
                    new RouteValueDictionary(htmlAttributes));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="html"></param>
        /// <param name="expression"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString LabelFor<TModel, TValue>(
                this HtmlHelper<TModel> html,
                Expression<Func<TModel, TValue>> expression,
                IDictionary<string, object> htmlAttributes) {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(
                    expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(
                    expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName
                    ?? htmlFieldName.Split('.').Last();
            if(String.IsNullOrEmpty(labelText)) {
                return MvcHtmlString.Empty;
            }
            TagBuilder tag = new TagBuilder("label");
            tag.MergeAttributes(htmlAttributes);
            tag.Attributes.Add("for",
                    html.ViewContext.ViewData.TemplateInfo
                        .GetFullHtmlFieldId(htmlFieldName));
            tag.SetInnerText(labelText);
            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}