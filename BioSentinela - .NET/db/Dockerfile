FROM container-registry.oracle.com/database/express:21.3.0

# Define um diretório de trabalho
WORKDIR /opt/oracle/scripts/setup

# Usuário não root
RUN useradd -ms /bin/bash orcluser
USER orcluser

# Variável de ambiente obrigatória
ENV ORACLE_CONN=Data Source=oracle.fiap.com.br:1521/orcl;User ID=xxxx;Password=xxxx;

EXPOSE 1521 5500
