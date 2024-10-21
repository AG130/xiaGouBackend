using SqlSugar;
namespace ModelLayer.PgEntitys.Costumer;

[SugarTable("Role")]
public class RolePo
{
    /// <summary>
    /// 角色字典表
    /// </summary>
    
    //数据库id
    [SugarColumn(IsIdentity = true,IsPrimaryKey = true)]
    public int DbId { set; get; }
    //角色代号
    public int RoleCode { set; get; }
    //角色名称
    public string RoleName { set; get; }
    //修改日期
    public DateTime EditedDate { set; get; }
    
}