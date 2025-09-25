<p align="center">
  <img src="https://i.ibb.co/rRLP2FMT/Whats-App-Image-2025-09-25-at-12-27-19.jpg" alt="TunadãoStore" width="400"/>
</p>


# TunadãoStore �

Uma aplicação de e-commerce completa desenvolvida com **ASP.NET Core** e **Angular**, criada do zero para demonstrar as melhores práticas de desenvolvimento full-stack.

## 📋 Sobre o Projeto

A TunadãoStore é um projeto educacional que implementa uma loja virtual completa, desde o backend até o frontend, utilizando tecnologias modernas e padrões de arquitetura consolidados no mercado.

## 🚀 Tecnologias Utilizadas

### Backend
- **ASP.NET Core** - Framework web principal
- **.NET CLI** - Ferramenta de linha de comando
- **Entity Framework Core** - ORM para acesso a dados
- **ASP.NET Identity** - Sistema de autenticação e autorização
- **Redis** - Cache para carrinho de compras
- **SignalR** - Comunicação em tempo real
- **Stripe** - Processamento de pagamentos com 3D Secure

### Frontend
- **Angular** - Framework frontend
- **Angular CLI** - Ferramenta de desenvolvimento
- **Angular Material** - Componentes de UI
- **Tailwind CSS** - Framework de estilos
- **Angular Reactive Forms** - Formulários reativos

### Cloud & DevOps
- **Azure** - Hospedagem e deploy da aplicação

## 🏗️ Arquitetura e Padrões

O projeto implementa diversos padrões e práticas recomendadas:

- **Repository Pattern** - Abstração da camada de dados
- **Unit of Work Pattern** - Gerenciamento de transações
- **Specification Pattern** - Consultas flexíveis e reutilizáveis
- **Múltiplos DbContext** - Separação de contextos por domínio
- **Lazy Loading** - Carregamento sob demanda de módulos
- **Autenticação Baseada em Roles** - Controle de acesso granular

## ✨ Funcionalidades

### 🛍️ Loja Virtual
- Catálogo de produtos com busca, filtros e ordenação
- Paginação inteligente de resultados
- Carrinho de compras persistente (Redis)
- Sistema completo de checkout

### 👤 Usuários
- Cadastro e login de usuários
- Autenticação com ASP.NET Identity
- Perfis de usuário diferenciados por roles

### 💳 Pagamentos
- Integração com Stripe
- Suporte a 3D Secure (padrões europeus)
- Processamento seguro de pagamentos

### 📱 Interface
- Design responsivo e moderno
- Componentes reutilizáveis
- Navegação por módulos lazy-loaded
- UX otimizada com Angular Material

## 🛠️ Configuração do Ambiente

### Pré-requisitos
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [Redis](https://redis.io/)
- [Visual Studio Code](https://code.visualstudio.com/) (recomendado)

### Instalação

1. **Clone o repositório**
   ```bash
   git clone https://github.com/net0well/tunadao-store.git
   cd tunadao-store
   ```

2. **Configure o Backend**
   ```bash
   cd API
   dotnet restore
   dotnet ef database update
   ```

3. **Configure o Frontend**
   ```bash
   cd client
   npm install
   ```

4. **Configure o Redis**
   - Instale e inicie o Redis localmente
   - Configure a string de conexão no `appsettings.json`

5. **Configure o Stripe**
   - Crie uma conta no Stripe
   - Adicione suas chaves no `appsettings.json`

### Executando a Aplicação

1. **Inicie o Backend**
   ```bash
   cd API
   dotnet run
   ```

2. **Inicie o Frontend**
   ```bash
   cd client
   ng serve
   ```

3. **Acesse a aplicação**
   - Frontend: `http://localhost:4200`
   - Backend API: `http://localhost:5000`

## 📚 Aprendizados

Este projeto demonstra:

- Criação de aplicações multi-projeto com .NET Core
- Desenvolvimento de SPAs com Angular
- Implementação de autenticação e autorização
- Integração com APIs de pagamento
- Deploy em cloud (Azure)
- Padrões de arquitetura para aplicações enterprise
- Desenvolvimento orientado a componentes
- Gerenciamento de estado no frontend

## 🤝 Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para:

1. Fazer fork do projeto
2. Criar uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abrir um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.
