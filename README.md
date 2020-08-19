# CleanCodeMasivian




/// Metodos

# 1 POST: https://localhost:44395/api/Roulette/ Creacion de ruletas
# 2 POST: https://localhost:44395/api/Roulette/{id}/OpenRoulette Apertura de ruleta
# 3 POST: https://localhost:44395/api/Roulette/{id}/BetRoulette Creacion de apuesta
# 4 DELETE: https://localhost:44395/api/Roulette/{id}/CloseRoulete Cierre de la ruleta
# 5 GET: https://localhost:44395/api/Roulette/ Listado de todas las ruletas

/// Metodos que necesitan parametros adicionales

# 3 POST: https://localhost:44395/api/Roulette/{id}/BetRoulette Creacion de apuesta

HEADER: userId

{
    "BetPosition": 1,
    "BetColor": "red",
    "BetMoney": 5425
}
