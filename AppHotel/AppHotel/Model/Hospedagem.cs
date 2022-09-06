using System;
using System.Collections.Generic;
using System.Text;

namespace AppHotel.Model
{
    public class Hospedagem
    {
        Suite quarto;

        int qntadultos;

        public int Qntadultos
        {
            get => qntadultos;

            set
            {
                if (value == 0)
                    throw new Exception("Por favor, informe a quantidade de adultos");

                qntadultos = value;
            }
        }

        public int Qntcriancas { get; set; }

        public Suite Quarto
        {
            get => quarto;

            set
            {
                if (value == null)
                    throw new Exception("Por favor, selecione uma suíte.");

                quarto = value;
            }
        }

        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadia
        {
            get
            {
                return DataCheckOut.Subtract(DataCheckIn).Days;
            }
        }

        public double ValorTotal
        {
            get => ((Qntadultos * Quarto.ValorDiariaAdulto) + (Qntcriancas * Quarto.ValorDiariaCrianca)) * Estadia;
        }


    }
}
