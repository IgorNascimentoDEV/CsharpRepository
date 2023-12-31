﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string csvFilePath = "C:\\Users\\WTINFO PC\\Documents\\trabalho_puc\\dados_puc\\DENGBR22 (1).csv"; // Substitua pelo caminho do seu arquivo CSV
        string connectionString = "Server=localhost;Port=3306;User Id=root;Password=123456;Database=dados";
        string sucessoFolder = "Sucesso";
        string falhaFolder = "Falha";

        if (!Directory.Exists(sucessoFolder))
        {
            Directory.CreateDirectory(sucessoFolder);
        }

        if (!Directory.Exists(falhaFolder))
        {
            Directory.CreateDirectory(falhaFolder);
        }

        List<Registro> registros = ReadCsvFile(csvFilePath);

        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            foreach (var item in registros)
            {
                if (InserirRegistroNoBanco(connection, item))
                {
                    Console.WriteLine("Registro inserido com sucesso: " + item.ID_AGRAVO);
                    MoverArquivoParaPasta(sucessoFolder, item);
                }
                else
                {
                    Console.WriteLine("Falha ao inserir registro");
                    MoverArquivoParaPasta(falhaFolder, item);
                }
            }
        }
    }

    static List<Registro> ReadCsvFile(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            return csv.GetRecords<Registro>().ToList();
        }
    }

    static bool InserirRegistroNoBanco(MySqlConnection connection, Registro item)
    {
        try
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO casos_dengue_2022_v2 (TP_NOT, ID_AGRAVO, DT_NOTIFIC, SEM_NOT, NU_ANO, SG_UF_NOT, ID_MUNICIP, ID_REGIONA, ID_UNIDADE, DT_SIN_PRI, SEM_PRI, ANO_NASC, NU_IDADE_N, CS_SEXO, CS_GESTANT, CS_RACA, CS_ESCOL_N, SG_UF, ID_MN_RESI, ID_RG_RESI, ID_PAIS, DT_INVEST, ID_OCUPA_N, FEBRE, MIALGIA, CEFALEIA, EXANTEMA, VOMITO, NAUSEA, DOR_COSTAS, CONJUNTVIT, ARTRITE, ARTRALGIA, PETEQUIA_N, LEUCOPENIA, LACO, DOR_RETRO, DIABETES, HEMATOLOG, HEPATOPAT, RENAL, HIPERTENSA, ACIDO_PEPT, AUTO_IMUNE, DT_CHIK_S1, DT_CHIK_S2, DT_PRNT, RES_CHIKS1, RES_CHIKS2, RESUL_PRNT, DT_SORO, RESUL_SORO, DT_NS1, RESUL_NS1, DT_VIRAL, RESUL_VI_N, DT_PCR, RESUL_PCR_, SOROTIPO, HISTOPA_N, IMUNOH_N, HOSPITALIZ, DT_INTERNA, UF, MUNICIPIO, TPAUTOCTO, COUFINF, COPAISINF, COMUNINF, CLASSI_FIN, CRITERIO, DOENCA_TRA, CLINC_CHIK, EVOLUCAO, DT_OBITO, DT_ENCERRA, ALRM_HIPOT, ALRM_PLAQ, ALRM_VOM, ALRM_SANG, ALRM_HEMAT, ALRM_ABDOM, ALRM_LETAR, ALRM_HEPAT, ALRM_LIQ, DT_ALRM, GRAV_PULSO, GRAV_CONV, GRAV_ENCH, GRAV_INSUF, GRAV_TAQUI, GRAV_EXTRE, GRAV_HIPOT, GRAV_HEMAT, GRAV_MELEN, GRAV_METRO, GRAV_SANG, GRAV_AST, GRAV_MIOC, GRAV_CONSC, GRAV_ORGAO, DT_GRAV, MANI_HEMOR, EPISTAXE, GENGIVO, METRO, PETEQUIAS, HEMATURA, SANGRAM, LACO_N, PLASMATICO, EVIDENCIA, PLAQ_MENOR, CON_FHD, TP_SISTEMA, NDUPLIC_N, DT_DIGITA, CS_FLXRET, FLXRECEBI, MIGRADO_W) " +
                                              "VALUES (@TP_NOT, @ID_AGRAVO, @DT_NOTIFIC, @SEM_NOT, @NU_ANO, @SG_UF_NOT, @ID_MUNICIP, @ID_REGIONA, @ID_UNIDADE, @DT_SIN_PRI, @SEM_PRI, @ANO_NASC, @NU_IDADE_N, @CS_SEXO, @CS_GESTANT, @CS_RACA, @CS_ESCOL_N, @SG_UF, @ID_MN_RESI, @ID_RG_RESI, @ID_PAIS, @DT_INVEST, @ID_OCUPA_N, @FEBRE, @MIALGIA, @CEFALEIA, @EXANTEMA, @VOMITO, @NAUSEA, @DOR_COSTAS, @CONJUNTVIT, @ARTRITE, @ARTRALGIA, @PETEQUIA_N, @LEUCOPENIA, @LACO, @DOR_RETRO, @DIABETES, @HEMATOLOG, @HEPATOPAT, @RENAL, @HIPERTENSA, @ACIDO_PEPT, @AUTO_IMUNE, @DT_CHIK_S1, @DT_CHIK_S2, @DT_PRNT, @RES_CHIKS1, @RES_CHIKS2, @RESUL_PRNT, @DT_SORO, @RESUL_SORO, @DT_NS1, @RESUL_NS1, @DT_VIRAL, @RESUL_VI_N, @DT_PCR, @RESUL_PCR_, @SOROTIPO, @HISTOPA_N, @IMUNOH_N, @HOSPITALIZ, @DT_INTERNA, @UF, @MUNICIPIO, @TPAUTOCTO, @COUFINF, @COPAISINF, @COMUNINF, @CLASSI_FIN, @CRITERIO, @DOENCA_TRA, @CLINC_CHIK, @EVOLUCAO, @DT_OBITO, @DT_ENCERRA, @ALRM_HIPOT, @ALRM_PLAQ, @ALRM_VOM, @ALRM_SANG, @ALRM_HEMAT, @ALRM_ABDOM, @ALRM_LETAR, @ALRM_HEPAT, @ALRM_LIQ, @DT_ALRM, @GRAV_PULSO, @GRAV_CONV, @GRAV_ENCH, @GRAV_INSUF, @GRAV_TAQUI, @GRAV_EXTRE, @GRAV_HIPOT, @GRAV_HEMAT, @GRAV_MELEN, @GRAV_METRO, @GRAV_SANG, @GRAV_AST, @GRAV_MIOC, @GRAV_CONSC, @GRAV_ORGAO, @DT_GRAV, @MANI_HEMOR, @EPISTAXE, @GENGIVO, @METRO, @PETEQUIAS, @HEMATURA, @SANGRAM, @LACO_N, @PLASMATICO, @EVIDENCIA, @PLAQ_MENOR, @CON_FHD, @TP_SISTEMA, @NDUPLIC_N, @DT_DIGITA, @CS_FLXRET, @FLXRECEBI, @MIGRADO_W);", connection);

            cmd.Parameters.AddWithValue("@TP_NOT", item.TP_NOT);
            cmd.Parameters.AddWithValue("@ID_AGRAVO", item.ID_AGRAVO);
            cmd.Parameters.AddWithValue("@DT_NOTIFIC", item.DT_NOTIFIC);
            cmd.Parameters.AddWithValue("@SEM_NOT", item.SEM_NOT);
            cmd.Parameters.AddWithValue("@NU_ANO", item.NU_ANO);
            cmd.Parameters.AddWithValue("@SG_UF_NOT", item.SG_UF_NOT);
            cmd.Parameters.AddWithValue("@ID_MUNICIP", item.ID_MUNICIP);
            cmd.Parameters.AddWithValue("@ID_REGIONA", item.ID_REGIONA);
            cmd.Parameters.AddWithValue("@ID_UNIDADE", item.ID_UNIDADE);
            cmd.Parameters.AddWithValue("@DT_SIN_PRI", item.DT_SIN_PRI);
            cmd.Parameters.AddWithValue("@SEM_PRI", item.SEM_PRI);
            cmd.Parameters.AddWithValue("@ANO_NASC", item.ANO_NASC);
            cmd.Parameters.AddWithValue("@NU_IDADE_N", item.NU_IDADE_N);
            cmd.Parameters.AddWithValue("@CS_SEXO", item.CS_SEXO);
            cmd.Parameters.AddWithValue("@CS_GESTANT", item.CS_GESTANT);
            cmd.Parameters.AddWithValue("@CS_RACA", item.CS_RACA);
            cmd.Parameters.AddWithValue("@CS_ESCOL_N", item.CS_ESCOL_N);
            cmd.Parameters.AddWithValue("@SG_UF", item.SG_UF);
            cmd.Parameters.AddWithValue("@ID_MN_RESI", item.ID_MN_RESI);
            cmd.Parameters.AddWithValue("@ID_RG_RESI", item.ID_RG_RESI);
            cmd.Parameters.AddWithValue("@ID_PAIS", item.ID_PAIS);
            cmd.Parameters.AddWithValue("@DT_INVEST", item.DT_INVEST);
            cmd.Parameters.AddWithValue("@ID_OCUPA_N", item.ID_OCUPA_N);
            cmd.Parameters.AddWithValue("@FEBRE", item.FEBRE);
            cmd.Parameters.AddWithValue("@MIALGIA", item.MIALGIA);
            cmd.Parameters.AddWithValue("@CEFALEIA", item.CEFALEIA);
            cmd.Parameters.AddWithValue("@EXANTEMA", item.EXANTEMA);
            cmd.Parameters.AddWithValue("@VOMITO", item.VOMITO);
            cmd.Parameters.AddWithValue("@NAUSEA", item.NAUSEA);
            cmd.Parameters.AddWithValue("@DOR_COSTAS", item.DOR_COSTAS);
            cmd.Parameters.AddWithValue("@CONJUNTVIT", item.CONJUNTVIT);
            cmd.Parameters.AddWithValue("@ARTRITE", item.ARTRITE);
            cmd.Parameters.AddWithValue("@ARTRALGIA", item.ARTRALGIA);
            cmd.Parameters.AddWithValue("@PETEQUIA_N", item.PETEQUIA_N);
            cmd.Parameters.AddWithValue("@LEUCOPENIA", item.LEUCOPENIA);
            cmd.Parameters.AddWithValue("@LACO", item.LACO);
            cmd.Parameters.AddWithValue("@DOR_RETRO", item.DOR_RETRO);
            cmd.Parameters.AddWithValue("@DIABETES", item.DIABETES);
            cmd.Parameters.AddWithValue("@HEMATOLOG", item.HEMATOLOG);
            cmd.Parameters.AddWithValue("@HEPATOPAT", item.HEPATOPAT);
            cmd.Parameters.AddWithValue("@RENAL", item.RENAL);
            cmd.Parameters.AddWithValue("@HIPERTENSA", item.HIPERTENSA);
            cmd.Parameters.AddWithValue("@ACIDO_PEPT", item.ACIDO_PEPT);
            cmd.Parameters.AddWithValue("@AUTO_IMUNE", item.AUTO_IMUNE);
            cmd.Parameters.AddWithValue("@DT_CHIK_S1", item.DT_CHIK_S1);
            cmd.Parameters.AddWithValue("@DT_CHIK_S2", item.DT_CHIK_S2);
            cmd.Parameters.AddWithValue("@DT_PRNT", item.DT_PRNT);
            cmd.Parameters.AddWithValue("@RES_CHIKS1", item.RES_CHIKS1);
            cmd.Parameters.AddWithValue("@RES_CHIKS2", item.RES_CHIKS2);
            cmd.Parameters.AddWithValue("@RESUL_PRNT", item.RESUL_PRNT);
            cmd.Parameters.AddWithValue("@DT_SORO", item.DT_SORO);
            cmd.Parameters.AddWithValue("@RESUL_SORO", item.RESUL_SORO);
            cmd.Parameters.AddWithValue("@DT_NS1", item.DT_NS1);
            cmd.Parameters.AddWithValue("@RESUL_NS1", item.RESUL_NS1);
            cmd.Parameters.AddWithValue("@DT_VIRAL", item.DT_VIRAL);
            cmd.Parameters.AddWithValue("@RESUL_VI_N", item.RESUL_VI_N);
            cmd.Parameters.AddWithValue("@DT_PCR", item.DT_PCR);
            cmd.Parameters.AddWithValue("@RESUL_PCR_", item.RESUL_PCR_);
            cmd.Parameters.AddWithValue("@SOROTIPO", item.SOROTIPO);
            cmd.Parameters.AddWithValue("@HISTOPA_N", item.HISTOPA_N);
            cmd.Parameters.AddWithValue("@IMUNOH_N", item.IMUNOH_N);
            cmd.Parameters.AddWithValue("@HOSPITALIZ", item.HOSPITALIZ);
            cmd.Parameters.AddWithValue("@DT_INTERNA", item.DT_INTERNA);
            cmd.Parameters.AddWithValue("@UF", item.UF);
            cmd.Parameters.AddWithValue("@MUNICIPIO", item.MUNICIPIO);
            cmd.Parameters.AddWithValue("@TPAUTOCTO", item.TPAUTOCTO);
            cmd.Parameters.AddWithValue("@COUFINF", item.COUFINF);
            cmd.Parameters.AddWithValue("@COPAISINF", item.COPAISINF);
            cmd.Parameters.AddWithValue("@COMUNINF", item.COMUNINF);
            cmd.Parameters.AddWithValue("@CLASSI_FIN", item.CLASSI_FIN);
            cmd.Parameters.AddWithValue("@CRITERIO", item.CRITERIO);
            cmd.Parameters.AddWithValue("@DOENCA_TRA", item.DOENCA_TRA);
            cmd.Parameters.AddWithValue("@CLINC_CHIK", item.CLINC_CHIK);
            cmd.Parameters.AddWithValue("@EVOLUCAO", item.EVOLUCAO);
            cmd.Parameters.AddWithValue("@DT_OBITO", item.DT_OBITO);
            cmd.Parameters.AddWithValue("@DT_ENCERRA", item.DT_ENCERRA);
            cmd.Parameters.AddWithValue("@ALRM_HIPOT", item.ALRM_HIPOT);
            cmd.Parameters.AddWithValue("@ALRM_PLAQ", item.ALRM_PLAQ);
            cmd.Parameters.AddWithValue("@ALRM_VOM", item.ALRM_VOM);
            cmd.Parameters.AddWithValue("@ALRM_SANG", item.ALRM_SANG);
            cmd.Parameters.AddWithValue("@ALRM_HEMAT", item.ALRM_HEMAT);
            cmd.Parameters.AddWithValue("@ALRM_ABDOM", item.ALRM_ABDOM);
            cmd.Parameters.AddWithValue("@ALRM_LETAR", item.ALRM_LETAR);
            cmd.Parameters.AddWithValue("@ALRM_HEPAT", item.ALRM_HEPAT);
            cmd.Parameters.AddWithValue("@ALRM_LIQ", item.ALRM_LIQ);
            cmd.Parameters.AddWithValue("@DT_ALRM", item.DT_ALRM);
            cmd.Parameters.AddWithValue("@GRAV_PULSO", item.GRAV_PULSO);
            cmd.Parameters.AddWithValue("@GRAV_CONV", item.GRAV_CONV);
            cmd.Parameters.AddWithValue("@GRAV_ENCH", item.GRAV_ENCH);
            cmd.Parameters.AddWithValue("@GRAV_INSUF", item.GRAV_INSUF);
            cmd.Parameters.AddWithValue("@GRAV_TAQUI", item.GRAV_TAQUI);
            cmd.Parameters.AddWithValue("@GRAV_EXTRE", item.GRAV_EXTRE);
            cmd.Parameters.AddWithValue("@GRAV_HIPOT", item.GRAV_HIPOT);
            cmd.Parameters.AddWithValue("@GRAV_HEMAT", item.GRAV_HEMAT);
            cmd.Parameters.AddWithValue("@GRAV_MELEN", item.GRAV_MELEN);
            cmd.Parameters.AddWithValue("@GRAV_METRO", item.GRAV_METRO);
            cmd.Parameters.AddWithValue("@GRAV_SANG", item.GRAV_SANG);
            cmd.Parameters.AddWithValue("@GRAV_AST", item.GRAV_AST);
            cmd.Parameters.AddWithValue("@GRAV_MIOC", item.GRAV_MIOC);
            cmd.Parameters.AddWithValue("@GRAV_CONSC", item.GRAV_CONSC);
            cmd.Parameters.AddWithValue("@GRAV_ORGAO", item.GRAV_ORGAO);
            cmd.Parameters.AddWithValue("@DT_GRAV", item.DT_GRAV);
            cmd.Parameters.AddWithValue("@MANI_HEMOR", item.MANI_HEMOR);
            cmd.Parameters.AddWithValue("@EPISTAXE", item.EPISTAXE);
            cmd.Parameters.AddWithValue("@GENGIVO", item.GENGIVO);
            cmd.Parameters.AddWithValue("@METRO", item.METRO);
            cmd.Parameters.AddWithValue("@PETEQUIAS", item.PETEQUIAS);
            cmd.Parameters.AddWithValue("@HEMATURA", item.HEMATURA);
            cmd.Parameters.AddWithValue("@SANGRAM", item.SANGRAM);
            cmd.Parameters.AddWithValue("@LACO_N", item.LACO_N);
            cmd.Parameters.AddWithValue("@PLASMATICO", item.PLASMATICO);
            cmd.Parameters.AddWithValue("@EVIDENCIA", item.EVIDENCIA);
            cmd.Parameters.AddWithValue("@PLAQ_MENOR", item.PLAQ_MENOR);
            cmd.Parameters.AddWithValue("@CON_FHD", item.CON_FHD);
            cmd.Parameters.AddWithValue("@COMPLICA", item.COMPLICA);
            cmd.Parameters.AddWithValue("@TP_SISTEMA", item.TP_SISTEMA);
            cmd.Parameters.AddWithValue("@NDUPLIC_N", item.NDUPLIC_N);
            cmd.Parameters.AddWithValue("@DT_DIGITA", item.DT_DIGITA);
            cmd.Parameters.AddWithValue("@CS_FLXRET", item.CS_FLXRET);
            cmd.Parameters.AddWithValue("@FLXRECEBI", item.FLXRECEBI);
            cmd.Parameters.AddWithValue("@MIGRADO_W", item.MIGRADO_W);

            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro na inserção: " + ex.Message);
            return false;
        }
    }

    static void MoverArquivoParaPasta(string pasta, Registro item)
    {
        // Suponha que o nome do arquivo esteja contido no objeto 'item'.
        string fileName = item.ID_AGRAVO;

        // Crie o arquivo CSV no caminho de destino.
        string destino = Path.Combine(pasta, fileName + ".csv");


        // Crie uma lista de valores a partir das propriedades do objeto Registro.
        var valores = new List<string>
    {
        item.TP_NOT?.ToString(),
        item.ID_AGRAVO,
        item.DT_NOTIFIC?.ToString(),
        item.SEM_NOT?.ToString(),
        item.NU_ANO?.ToString(),
        item.SG_UF_NOT?.ToString(),
        item.ID_MUNICIP?.ToString(),
        item.ID_REGIONA?.ToString(),
        item.ID_UNIDADE?.ToString(),
        item.DT_SIN_PRI,
        item.SEM_PRI?.ToString(),
        item.ANO_NASC?.ToString(),
        item.NU_IDADE_N?.ToString(),
        item.CS_SEXO,
        item.CS_GESTANT?.ToString(),
        item.CS_RACA?.ToString(),
        item.CS_ESCOL_N?.ToString(),
        item.SG_UF?.ToString(),
        item.ID_MN_RESI?.ToString(),
        item.ID_RG_RESI?.ToString(),
        item.ID_PAIS?.ToString(),
        item.DT_INVEST,
        item.ID_OCUPA_N?.ToString(),
        item.FEBRE?.ToString(),
        item.MIALGIA?.ToString(),
        item.CEFALEIA?.ToString(),
        item.EXANTEMA?.ToString(),
        item.VOMITO?.ToString(),
        item.NAUSEA?.ToString(),
        item.DOR_COSTAS?.ToString(),
        item.CONJUNTVIT?.ToString(),
        item.ARTRITE?.ToString(),
        item.ARTRALGIA?.ToString(),
        item.PETEQUIA_N?.ToString(),
        item.LEUCOPENIA?.ToString(),
        item.LACO?.ToString(),
        item.DOR_RETRO?.ToString(),
        item.DIABETES?.ToString(),
        item.HEMATOLOG?.ToString(),
        item.HEPATOPAT?.ToString(),
        item.RENAL?.ToString(),
        item.HIPERTENSA?.ToString(),
        item.ACIDO_PEPT?.ToString(),
        item.AUTO_IMUNE?.ToString(),
        item.DT_CHIK_S1,
        item.DT_CHIK_S2,
        item.DT_PRNT,
        item.RES_CHIKS1?.ToString(),
        item.RES_CHIKS2?.ToString(),
        item.RESUL_PRNT?.ToString(),
        item.DT_SORO,
        item.RESUL_SORO?.ToString(),
        item.DT_NS1,
        item.RESUL_NS1?.ToString(),
        item.DT_VIRAL,
        item.RESUL_VI_N?.ToString(),
        item.DT_PCR,
        item.RESUL_PCR_?.ToString(),
        item.SOROTIPO?.ToString(),
        item.HISTOPA_N?.ToString(),
        item.IMUNOH_N?.ToString(),
        item.HOSPITALIZ?.ToString(),
        item.DT_INTERNA,
        item.UF?.ToString(),
        item.MUNICIPIO?.ToString(),
        item.TPAUTOCTO?.ToString(),
        item.COUFINF?.ToString(),
        item.COPAISINF?.ToString(),
        item.COMUNINF?.ToString(),
        item.CLASSI_FIN?.ToString(),
        item.CRITERIO?.ToString(),
        item.DOENCA_TRA?.ToString(),
        item.CLINC_CHIK?.ToString(),
        item.EVOLUCAO?.ToString(),
        item.DT_OBITO,
        item.DT_ENCERRA,
        item.ALRM_HIPOT?.ToString(),
        item.ALRM_PLAQ?.ToString(),
        item.ALRM_VOM?.ToString(),
        item.ALRM_SANG?.ToString(),
        item.ALRM_HEMAT?.ToString(),
        item.ALRM_ABDOM?.ToString(),
        item.ALRM_LETAR?.ToString(),
        item.ALRM_HEPAT?.ToString(),
        item.ALRM_LIQ?.ToString(),
        item.DT_ALRM,
        item.GRAV_PULSO?.ToString(),
        item.GRAV_CONV?.ToString(),
        item.GRAV_ENCH?.ToString(),
        item.GRAV_INSUF?.ToString(),
        item.GRAV_TAQUI?.ToString(),
        item.GRAV_EXTRE?.ToString(),
        item.GRAV_HIPOT?.ToString(),
        item.GRAV_HEMAT?.ToString(),
        item.GRAV_MELEN?.ToString(),
        item.GRAV_METRO?.ToString(),
        item.GRAV_SANG?.ToString(),
        item.GRAV_AST?.ToString(),
        item.GRAV_MIOC?.ToString(),
        item.GRAV_CONSC?.ToString(),
        item.GRAV_ORGAO?.ToString(),
        item.DT_GRAV,
        item.MANI_HEMOR?.ToString(),
        item.EPISTAXE?.ToString(),
        item.GENGIVO?.ToString(),
        item.METRO?.ToString(),
        item.PETEQUIAS?.ToString(),
        item.HEMATURA?.ToString(),
        item.SANGRAM?.ToString(),
        item.LACO_N?.ToString(),
        item.PLASMATICO?.ToString(),
        item.EVIDENCIA?.ToString(),
        item.PLAQ_MENOR?.ToString(),
        item.CON_FHD?.ToString(),
        item.COMPLICA?.ToString(),
        item.TP_SISTEMA?.ToString(),
        item.NDUPLIC_N?.ToString(),
        item.DT_DIGITA,
        item.CS_FLXRET?.ToString(),
        item.FLXRECEBI?.ToString(),
        item.MIGRADO_W?.ToString()
    };

        // Crie a linha CSV combinando os valores com vírgulas.
        string linhaCSV = string.Join(",", valores);

        // Escreva a linha CSV no arquivo.
        File.WriteAllText(destino, linhaCSV);
    }
}