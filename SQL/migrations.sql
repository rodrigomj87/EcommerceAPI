IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321031149_initial')
BEGIN
    CREATE TABLE [Fornecedores] (
        [Id] uniqueidentifier NOT NULL,
        [Nome] varchar(200) NOT NULL,
        [Documento] varchar(14) NOT NULL,
        [TipoFornecedor] int NOT NULL,
        [Ativo] bit NOT NULL,
        CONSTRAINT [PK_Fornecedores] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321031149_initial')
BEGIN
    CREATE TABLE [Enderecos] (
        [Id] uniqueidentifier NOT NULL,
        [FornecedorId] uniqueidentifier NOT NULL,
        [Logradouro] varchar(200) NOT NULL,
        [Numero] varchar(50) NOT NULL,
        [Complemento] varchar(250) NOT NULL,
        [Cep] varchar(8) NOT NULL,
        [Bairro] varchar(100) NOT NULL,
        [Cidade] varchar(100) NOT NULL,
        [Estado] varchar(50) NOT NULL,
        CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Enderecos_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321031149_initial')
BEGIN
    CREATE TABLE [Produtos] (
        [Id] uniqueidentifier NOT NULL,
        [FornecedorId] uniqueidentifier NOT NULL,
        [Nome] varchar(200) NOT NULL,
        [Descricao] varchar(1000) NOT NULL,
        [Imagem] varchar(100) NOT NULL,
        [Valor] decimal(18,2) NOT NULL,
        [DataCadastro] datetime2 NOT NULL,
        [Ativo] bit NOT NULL,
        CONSTRAINT [PK_Produtos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Produtos_Fornecedores_FornecedorId] FOREIGN KEY ([FornecedorId]) REFERENCES [Fornecedores] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321031149_initial')
BEGIN
    CREATE UNIQUE INDEX [IX_Enderecos_FornecedorId] ON [Enderecos] ([FornecedorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321031149_initial')
BEGIN
    CREATE INDEX [IX_Produtos_FornecedorId] ON [Produtos] ([FornecedorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321031149_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230321031149_initial', N'6.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Produtos]') AND [c].[name] = N'Ativo');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Produtos] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Produtos] ADD DEFAULT CAST(1 AS bit) FOR [Ativo];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [Categorias] (
        [Id] uniqueidentifier NOT NULL,
        [Nome] varchar(30) NOT NULL,
        [Ativo] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_Categorias] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [Clientes] (
        [Id] uniqueidentifier NOT NULL,
        [Nome] varchar(50) NOT NULL,
        [Email] varchar(100) NOT NULL,
        [DataCadastro] datetime NOT NULL,
        CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [MetodosPagamento] (
        [Id] uniqueidentifier NOT NULL,
        [Nome] varchar(50) NOT NULL,
        [Descricao] varchar(100) NOT NULL,
        [Ativo] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_MetodosPagamento] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [ProdutoVariacoes] (
        [Id] uniqueidentifier NOT NULL,
        [ProdutoId] uniqueidentifier NOT NULL,
        [Descricao] varchar(200) NOT NULL,
        [valor] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_ProdutoVariacoes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProdutoVariacoes_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [UnidadesFederacao] (
        [Id] uniqueidentifier NOT NULL,
        [Sigla] varchar(2) NOT NULL,
        [Nome] varchar(50) NOT NULL,
        CONSTRAINT [PK_UnidadesFederacao] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [VendaStatus] (
        [Id] uniqueidentifier NOT NULL,
        [Nome] varchar(50) NOT NULL,
        [Ativo] bit NOT NULL DEFAULT CAST(1 AS bit),
        CONSTRAINT [PK_VendaStatus] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [CategoriasProdutos] (
        [ProdutoId] uniqueidentifier NOT NULL,
        [CategoriaId] uniqueidentifier NOT NULL,
        [Id] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_CategoriasProdutos] PRIMARY KEY ([ProdutoId], [CategoriaId]),
        CONSTRAINT [FK_CategoriasProdutos_Categorias_CategoriaId] FOREIGN KEY ([CategoriaId]) REFERENCES [Categorias] ([Id]),
        CONSTRAINT [FK_CategoriasProdutos_Produtos_ProdutoId] FOREIGN KEY ([ProdutoId]) REFERENCES [Produtos] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [ProdutoVariacaoDetalhes] (
        [Id] uniqueidentifier NOT NULL,
        [ProdutoVariacaoId] uniqueidentifier NOT NULL,
        [Item] varchar(100) NOT NULL,
        [Descricao] varchar(1000) NOT NULL,
        CONSTRAINT [PK_ProdutoVariacaoDetalhes] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProdutoVariacaoDetalhes_ProdutoVariacoes_ProdutoVariacaoId] FOREIGN KEY ([ProdutoVariacaoId]) REFERENCES [ProdutoVariacoes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [Cidades] (
        [Id] uniqueidentifier NOT NULL,
        [Nome] varchar(50) NOT NULL,
        [UnidadeFederacaoId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_Cidades] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Cidades_UnidadesFederacao_UnidadeFederacaoId] FOREIGN KEY ([UnidadeFederacaoId]) REFERENCES [UnidadesFederacao] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [PedidosVenda] (
        [Id] uniqueidentifier NOT NULL,
        [NumeroPedido] varchar(20) NOT NULL,
        [DataPedido] datetime NOT NULL,
        [DataPrevistaEntrega] datetime NOT NULL,
        [ClienteId] uniqueidentifier NOT NULL,
        [EnderecoEntregaId] uniqueidentifier NOT NULL,
        [MetodoPagamentoId] uniqueidentifier NOT NULL,
        [ValorProdutos] decimal(18,2) NOT NULL,
        [ValorFrete] decimal(18,2) NOT NULL,
        [VendaStatusId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_PedidosVenda] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PedidosVenda_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]),
        CONSTRAINT [FK_PedidosVenda_Enderecos_EnderecoEntregaId] FOREIGN KEY ([EnderecoEntregaId]) REFERENCES [Enderecos] ([Id]),
        CONSTRAINT [FK_PedidosVenda_MetodosPagamento_MetodoPagamentoId] FOREIGN KEY ([MetodoPagamentoId]) REFERENCES [MetodosPagamento] ([Id]),
        CONSTRAINT [FK_PedidosVenda_VendaStatus_VendaStatusId] FOREIGN KEY ([VendaStatusId]) REFERENCES [VendaStatus] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [ClientesEnderecos] (
        [Id] uniqueidentifier NOT NULL,
        [ClienteId] uniqueidentifier NOT NULL,
        [Logradouro] varchar(100) NOT NULL,
        [Numero] varchar(10) NOT NULL,
        [Complemento] varchar(50) NOT NULL,
        [Bairro] varchar(50) NOT NULL,
        [CEP] varchar(8) NOT NULL,
        [CidadeId] uniqueidentifier NOT NULL,
        [NomeRecebedor] varchar(100) NOT NULL,
        [EhEnderecoPadrao] bit NOT NULL,
        CONSTRAINT [PK_ClientesEnderecos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ClientesEnderecos_Cidades_CidadeId] FOREIGN KEY ([CidadeId]) REFERENCES [Cidades] ([Id]),
        CONSTRAINT [FK_ClientesEnderecos_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE TABLE [PedidosVendaProdutos] (
        [Id] uniqueidentifier NOT NULL,
        [PedidoVendaId] uniqueidentifier NOT NULL,
        [ProdutoVariacaoId] uniqueidentifier NOT NULL,
        [Quantidade] int NOT NULL,
        [Valor] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_PedidosVendaProdutos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PedidosVendaProdutos_PedidosVenda_PedidoVendaId] FOREIGN KEY ([PedidoVendaId]) REFERENCES [PedidosVenda] ([Id]),
        CONSTRAINT [FK_PedidosVendaProdutos_ProdutoVariacoes_ProdutoVariacaoId] FOREIGN KEY ([ProdutoVariacaoId]) REFERENCES [ProdutoVariacoes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_CategoriasProdutos_CategoriaId] ON [CategoriasProdutos] ([CategoriaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_Cidades_UnidadeFederacaoId] ON [Cidades] ([UnidadeFederacaoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_ClientesEnderecos_CidadeId] ON [ClientesEnderecos] ([CidadeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_ClientesEnderecos_ClienteId] ON [ClientesEnderecos] ([ClienteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_PedidosVenda_ClienteId] ON [PedidosVenda] ([ClienteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_PedidosVenda_EnderecoEntregaId] ON [PedidosVenda] ([EnderecoEntregaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_PedidosVenda_MetodoPagamentoId] ON [PedidosVenda] ([MetodoPagamentoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_PedidosVenda_VendaStatusId] ON [PedidosVenda] ([VendaStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_PedidosVendaProdutos_PedidoVendaId] ON [PedidosVendaProdutos] ([PedidoVendaId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_PedidosVendaProdutos_ProdutoVariacaoId] ON [PedidosVendaProdutos] ([ProdutoVariacaoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_ProdutoVariacaoDetalhes_ProdutoVariacaoId] ON [ProdutoVariacaoDetalhes] ([ProdutoVariacaoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    CREATE INDEX [IX_ProdutoVariacoes_ProdutoId] ON [ProdutoVariacoes] ([ProdutoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230321214507_Full DB')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230321214507_Full DB', N'6.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322010233_carrinho')
BEGIN
    CREATE TABLE [Carrinhos] (
        [Id] uniqueidentifier NOT NULL,
        [ClienteId] uniqueidentifier NOT NULL,
        [ProdutoVariacaoId] uniqueidentifier NOT NULL,
        [Valor] decimal(18,2) NOT NULL,
        [Quantidade] int NOT NULL,
        [Parcelas] int NOT NULL,
        [GerouPedido] bit NOT NULL DEFAULT CAST(0 AS bit),
        CONSTRAINT [PK_Carrinhos] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Carrinhos_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]),
        CONSTRAINT [FK_Carrinhos_ProdutoVariacoes_ProdutoVariacaoId] FOREIGN KEY ([ProdutoVariacaoId]) REFERENCES [ProdutoVariacoes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322010233_carrinho')
BEGIN
    CREATE INDEX [IX_Carrinhos_ClienteId] ON [Carrinhos] ([ClienteId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322010233_carrinho')
BEGIN
    CREATE INDEX [IX_Carrinhos_ProdutoVariacaoId] ON [Carrinhos] ([ProdutoVariacaoId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322010233_carrinho')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230322010233_carrinho', N'6.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322011817_PedidoVenda')
BEGIN
    ALTER TABLE [PedidosVenda] DROP CONSTRAINT [FK_PedidosVenda_Enderecos_EnderecoEntregaId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322011817_PedidoVenda')
BEGIN
    ALTER TABLE [PedidosVenda] ADD CONSTRAINT [FK_PedidosVenda_ClientesEnderecos_EnderecoEntregaId] FOREIGN KEY ([EnderecoEntregaId]) REFERENCES [ClientesEnderecos] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322011817_PedidoVenda')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230322011817_PedidoVenda', N'6.0.3');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322033613_ClienteTelefone')
BEGIN
    ALTER TABLE [Clientes] ADD [Telefone] varchar(11) NOT NULL DEFAULT '';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230322033613_ClienteTelefone')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230322033613_ClienteTelefone', N'6.0.3');
END;
GO

COMMIT;
GO

