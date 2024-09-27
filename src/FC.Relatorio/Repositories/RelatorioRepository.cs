using FC.Relatorio.DTOs;
using FC.Relatorio.Infra.Settings;
using FC.Relatorio.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FC.Relatorio.Repositories
{
    public class RelatorioRepository : IRelatorioRepository

    {
        private readonly IMongoCollection<MovimentacaoCaixaDTO> _movimentacoesCollection;
        public RelatorioRepository(IOptions<MongoDBSettings> mongoDBSettings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _movimentacoesCollection = database.GetCollection<MovimentacaoCaixaDTO>(mongoDBSettings.Value.MovimentacoesCollectionName);
        }
        public async Task CreateAsync(MovimentacaoCaixaDTO movimentacaoCaixaDTO)
        {
            await _movimentacoesCollection.InsertOneAsync(movimentacaoCaixaDTO);
        }

        public Task<List<MovimentacaoCaixaDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
