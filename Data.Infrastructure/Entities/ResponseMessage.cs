using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class ResponseMessage:BaseEntity
{
    public string Key { get; set; }//Enum için string yapıya karşılık gelecek//Success
    public string MessageTR { get; set; }//Başarılı
    public string MessageEng { get; set; }//Success
    public string MessageDautch { get; set; }//S
    public string MessageDautKrt { get; set; }//Serqefti

}
