using System;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.IO;

string jsonFilePath = @"C:\Users\igor.sn\Documents\projetinho do well\20230928185841 (1).json"; // caminho do arquivo JSON.
string connectionString = "Server=localhost;Port=3306;User Id=root;Password=123456789;Database=insertJson"; //conecxão com o banco
string sucessoFolder = "Sucesso"; // pasta pra registra os que foram pro banco
string falhaFolder = "Falha"; // pasta pra registra os que não foram pro banco

//Cria pastas
try
{
    if (!Directory.Exists(sucessoFolder))
    {
        Directory.CreateDirectory(sucessoFolder);
    }

    if (!Directory.Exists(falhaFolder))
    {
        Directory.CreateDirectory(falhaFolder);
    }


    using (var connection = new MySqlConnection(connectionString))
    {
        connection.Open();

        var jsonText = File.ReadAllText(jsonFilePath);
        var jsonData = JsonConvert.DeserializeObject<List<Registro>>(jsonText);

        foreach (var item in jsonData)
        {
            if (InserirNoBanco(connection, item))
            {
                Console.WriteLine($"Registro inserido com sucesso: {item.t15_id}");
                SalvarRegistroEmPasta(sucessoFolder, item);
            }
            else
            {
                Console.WriteLine($"Falha ao inserir registro: {item.t15_id}");
                SalvarRegistroEmPasta(falhaFolder, item);
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

bool InserirNoBanco(MySqlConnection connection, Registro item)
{
    try
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO Registro (t15_id, t15_descricao, t15_tipo, t15_kmAtual, t15_latitude, t15_longitude, t15_dataHora, t15_obsMotorista, t15_romaneio_id, t15_data_registro, t15_entrega_id, t15_motivo_devol_reent_id, t15_usuario_responsavel, t02_descricao, t32_seq_pedido_erp, t32_valor, t32_peso, t32_volume_m3, t32_nf, t05_codigo_erp, t05_codigo_erp_aj1, t05_codigo_erp_aj2, t05_codigo_erp_aj3, t05_codigo_erp_aj4, t10_carga_formada_erp, t06_codigo_erp, t06_placa, t44_codigo_erp, t15_link_foto, descricao_motivo_devol_reent, codigo_erp_motivo_devol_reent, peso_agendado, t166_descricao, t166_medida, t32_numero_recibo_coleta, t32_qtd_informado, t32_qtd_volume_informado_coleta, t32_serie_nf, t43_codigo_filial_erp, peso_coletado) " +
                             "VALUES (@t15_id, @t15_descricao, @t15_tipo, @t15_kmAtual, @t15_latitude, @t15_longitude, @t15_dataHora, @t15_obsMotorista, @t15_romaneio_id, @t15_data_registro, @t15_entrega_id, @t15_motivo_devol_reent_id, @t15_usuario_responsavel, @t02_descricao, @t32_seq_pedido_erp, @t32_valor, @t32_peso, @t32_volume_m3, @t32_nf, @t05_codigo_erp, @t05_codigo_erp_aj1, @t05_codigo_erp_aj2, @t05_codigo_erp_aj3, @t05_codigo_erp_aj4, @t10_carga_formada_erp, @t06_codigo_erp, @t06_placa, @t44_codigo_erp, @t15_link_foto, @descricao_motivo_devol_reent, @codigo_erp_motivo_devol_reent, @peso_agendado, @t166_descricao, @t166_medida, @t32_numero_recibo_coleta, @t32_qtd_informado, @t32_qtd_volume_informado_coleta, @t32_serie_nf, @t43_codigo_filial_erp, @peso_coletado)";
            
            // Defina os parâmetros necessários com os valores do objeto 'item'.
            cmd.Parameters.AddWithValue("@t15_id", item.t15_id);
            cmd.Parameters.AddWithValue("@t15_descricao", item.t15_descricao);
            cmd.Parameters.AddWithValue("@t15_tipo", item.t15_tipo);
            cmd.Parameters.AddWithValue("@t15_kmAtual", item.t15_kmAtual);
            cmd.Parameters.AddWithValue("@t15_latitude", item.t15_latitude);
            cmd.Parameters.AddWithValue("@t15_longitude", item.t15_longitude);
            cmd.Parameters.AddWithValue("@t15_dataHora", item.t15_dataHora);
            cmd.Parameters.AddWithValue("@t15_obsMotorista", item.t15_obsMotorista);
            cmd.Parameters.AddWithValue("@t15_romaneio_id", item.t15_romaneio_id);
            cmd.Parameters.AddWithValue("@t15_data_registro", item.t15_data_registro);
            cmd.Parameters.AddWithValue("@t15_entrega_id", item.t15_entrega_id);
            cmd.Parameters.AddWithValue("@t15_motivo_devol_reent_id", item.t15_motivo_devol_reent_id);
            cmd.Parameters.AddWithValue("@t15_usuario_responsavel", item.t15_usuario_responsavel);
            cmd.Parameters.AddWithValue("@t02_descricao", item.t02_descricao);
            cmd.Parameters.AddWithValue("@t32_seq_pedido_erp", item.t32_seq_pedido_erp);
            cmd.Parameters.AddWithValue("@t32_valor", item.t32_valor);
            cmd.Parameters.AddWithValue("@t32_peso", item.t32_peso);
            cmd.Parameters.AddWithValue("@t32_volume_m3", item.t32_volume_m3);
            cmd.Parameters.AddWithValue("@t32_nf", item.t32_nf);
            cmd.Parameters.AddWithValue("@t05_codigo_erp", item.t05_codigo_erp);
            cmd.Parameters.AddWithValue("@t05_codigo_erp_aj1", item.t05_codigo_erp_aj1);
            cmd.Parameters.AddWithValue("@t05_codigo_erp_aj2", item.t05_codigo_erp_aj2);
            cmd.Parameters.AddWithValue("@t05_codigo_erp_aj3", item.t05_codigo_erp_aj3);
            cmd.Parameters.AddWithValue("@t05_codigo_erp_aj4", item.t05_codigo_erp_aj4);
            cmd.Parameters.AddWithValue("@t10_carga_formada_erp", item.t10_carga_formada_erp);
            cmd.Parameters.AddWithValue("@t06_codigo_erp", item.t06_codigo_erp);
            cmd.Parameters.AddWithValue("@t06_placa", item.t06_placa);
            cmd.Parameters.AddWithValue("@t44_codigo_erp", item.t44_codigo_erp);
            cmd.Parameters.AddWithValue("@t15_link_foto", item.t15_link_foto);
            cmd.Parameters.AddWithValue("@descricao_motivo_devol_reent", item.descricao_motivo_devol_reent);
            cmd.Parameters.AddWithValue("@codigo_erp_motivo_devol_reent", item.codigo_erp_motivo_devol_reent);
            cmd.Parameters.AddWithValue("@peso_agendado", item.peso_agendado);
            cmd.Parameters.AddWithValue("@t166_descricao", item.t166_descricao);
            cmd.Parameters.AddWithValue("@t166_medida", item.t166_medida);
            cmd.Parameters.AddWithValue("@t32_numero_recibo_coleta", item.t32_numero_recibo_coleta);
            cmd.Parameters.AddWithValue("@t32_qtd_informado", item.t32_qtd_informado);
            cmd.Parameters.AddWithValue("@t32_qtd_volume_informado_coleta", item.t32_qtd_volume_informado_coleta);
            cmd.Parameters.AddWithValue("@t32_serie_nf", item.t32_serie_nf);
            cmd.Parameters.AddWithValue("@t43_codigo_filial_erp", item.t43_codigo_filial_erp);
            cmd.Parameters.AddWithValue("@peso_coletado", item.peso_coletado);
            
            // Executa a instrução SQL de inserção.
            cmd.ExecuteNonQuery();
            
            return true; // Sucesso na inserção.
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro na inserção: {ex.Message}");
        return false; // Falha na inserção.
    }
}

void SalvarRegistroEmPasta(string pasta, Registro item)
{
    var json = JsonConvert.SerializeObject(item);
    var arquivo = Path.Combine(pasta, $"{item.t15_id}.json");
    File.Move(arquivo, json);
}
