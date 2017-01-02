﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WB.CaixaEletronico.usuario;

namespace WB.CaixaEletronico.contas
{
    abstract class Conta
    {
        public int numero;
        public Cliente titular;
        public double Saldo { get; protected set; }
        public int agencia;

        public Conta(Cliente cliente) {
            this.titular = cliente;
        }

        public Conta()
        {

        }

        public abstract void Saca(double valor_saque);

        public void Deposita(double valor_deposito)
        {
            if (valor_deposito > 0)
            {
                this.Saldo += valor_deposito;

            }
            if (Double.IsNaN(valor_deposito))
            {
                throw new FormatException(); 
            }
        }

        public bool Transfere(double valor_transfere,Conta destino)
        {
            if(!this.Equals(destino))
            {
                this.Saca(valor_transfere);
                destino.Deposita(valor_transfere);
                return true;
            }
            return false;
            throw new Exception; 
        }

        public override bool Equals(object obj)
        {
            Conta conta = (Conta)obj;
            return this.titular.nome.Equals(conta.titular.nome);
        }
    }
}
