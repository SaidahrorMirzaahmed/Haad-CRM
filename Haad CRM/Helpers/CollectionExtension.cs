using Haad_CRM.Models.Common;
namespace Haad_CRM.Helpers;

public static class CollectionExtention
{
    public static T Create<T>(this List<T> list, T model) where T : Auditable
    {
        var lastId = list.Count == 0 ? 1 : list.Last().Id + 1;
        model.Id = lastId;
        list.Add(model);
        return list.Last();
    }
}