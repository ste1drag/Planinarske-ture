using Reviewing.Application.Pagination;
using PagedList.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Routing;


namespace Reviewing.Application.Pagination
{
    public static class PaginationMetadataFactory
    {
        public static PaginationMetadata FromPagedList<T>(
            IPagedList<T> pagedList,
            IUrlHelper urlHelper,
            string actionName,
            object? routeValues = null,
            string? scheme = null)
        {
            return new PaginationMetadata
            {
                CurrentPage = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalItemCount,
                TotalPages = pagedList.PageCount,
                PreviousPageUrl = pagedList.HasPreviousPage
                    ? urlHelper.Action(new UrlActionContext
                    {
                        Action = actionName,
                        Controller = null,
                        Values = MergeRouteValues(routeValues, pagedList.PageNumber - 1, pagedList.PageSize),
                        Protocol = scheme
                    })
                    : null,
                NextPageUrl = pagedList.HasNextPage
                    ? urlHelper.Action(new UrlActionContext
                    {
                        Action = actionName,
                        Controller = null,
                        Values = MergeRouteValues(routeValues, pagedList.PageNumber + 1, pagedList.PageSize),
                        Protocol = scheme
                    })
                    : null
            };
        }

        private static object MergeRouteValues(object? baseValues, int pageNumber, int pageSize)
        {
            var dict = baseValues != null
                ? new RouteValueDictionary(baseValues)
                : new RouteValueDictionary();
            dict["pageNumber"] = pageNumber;
            dict["pageSize"] = pageSize;
            return dict;
        }
    }
}