#!/bin/bash
set -a
source .env
set +a

 dotnet ef dbcontext scaffold "$CONN_STR" Npgsql.EntityFrameworkCore.PostgreSQL   --context MyDbContext     --no-onconfiguring     --schema petshop --force 