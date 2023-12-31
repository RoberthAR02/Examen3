﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen3
{
    public partial class Form
    {
        private string Nombre;
        private int Edad;
        private string Correo;
        private int Partido;

        public string getNombre()
        {
            return Nombre;
        }

        public int getEdad()
        {
            return Edad;
        }

        public string getCorreo()
        {
            return Correo;
        }

        public int getPartido()
        {
            return Partido;
        }

        public void setNombre(string nombre)
        {
            Nombre = nombre;
        }

        public void setEdad(int edad)
        {
            Edad = edad;
        }

        public void setCorreo(string correo)
        {
            Correo = correo;
        }

        public void setPartido(int partido)
        {
            Partido = partido;
        }

        public bool save()
        {
            int ret = Examen3.Data_Base.insertarFormulario(Nombre, Edad, Correo, Partido);

            return ret > 0;

        }
    }
}
