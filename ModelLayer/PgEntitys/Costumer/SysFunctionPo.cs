using SqlSugar;
namespace ModelLayer.PgEntitys.Costumer;

[SugarTable("SysFunction")]
public class SysFunctionPo
{
    //数据库id
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int DbId { get; set; }
    //功能代号
    public int FuncCode { get; set; }
    //功能名称
    public string FuncName { get; set; }
    //功能分类
    public string FuncClass { get; set; }
}