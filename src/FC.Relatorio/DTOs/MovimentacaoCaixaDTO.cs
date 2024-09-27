using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FC.Relatorio.DTOs
{
    public class MovimentacaoCaixaDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("valor")]
        public decimal valor { get; set; }
        [BsonElement("Tipo")]
        public TipoMovimentacao tipo { get; set; } // Entrada ou Saída
        [BsonElement("datamovimentacao")]
        public DateTime datamovimentacao { get; set; }
    }
    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }
}
