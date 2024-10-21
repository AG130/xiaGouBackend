using SqlSugar;
namespace ModelLayer.PgEntitys.Consumer;

[SugarTable("Authority")]
public class AuthorityPo
{
    /// <summary>
    /// 角色与功能信息关联
    /// </summary>
    
    //数据库id
    [SugarColumn(IsIdentity = true,IsPrimaryKey = true)]
    public int DbId { get; set; }
    //角色代号
    public int RoleCode { get; set; }
    //功能代号
    public int FuncCode { get; set; }
    //增
    public bool AddFunc { get; set; }
    //删
    public bool DelFunc { get; set; }
    //改
    public bool EditFunc { get; set; }
    //查
    public bool GetFunc { get; set; }
    
}