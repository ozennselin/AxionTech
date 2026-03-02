using System.Text.Json.Serialization;

namespace Core.Dtos;

public class APIResponseDTO<TEntity>//Global
{
    public TEntity Data { get; set; }

    [JsonIgnore]//Http statü kodlarından bağımsız geliştireceğim, Http JsonIgnore gelen statü kodlarını görmezden gel

    public int StatuCode { get; set; }//Id=> 2xx,3xx,4xx,5xx

    public List<string> Errors { get; set; }//

    public static APIResponseDTO<TEntity> Success(int statuCode, TEntity data)
    {
        return new APIResponseDTO<TEntity> { Data = data, StatuCode = statuCode };
    }

    public static APIResponseDTO<TEntity> Success(int statuCode)//200
    {
        return new APIResponseDTO<TEntity> { StatuCode = statuCode };
    }

    // List<string>=> Delegate
    public static APIResponseDTO<TEntity> Fail(int statuCode, List<string> errors)//404 stok Ondalık olmaz,404 Name requared=> zorunlu
    {
        return new APIResponseDTO<TEntity> { StatuCode = statuCode, Errors = errors };
    }

    public static APIResponseDTO<TEntity> Fail(int statuCode, string errors)//404 stok Ondalık olmaz
    {
        return new APIResponseDTO<TEntity> { StatuCode = statuCode, Errors = new List<string> { errors } };
    }
}