﻿using Delivery.Domain.User;

namespace Delivery.Repositories.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {

        /// <summary>
        /// Bloqueas un usuario, te devuelve un string dependiendo de si se logró hacer la operación
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        Task<string> Bloquear_Usuario(int UID);

        /// <summary>
        /// Desbloqueas un usuario, te devuelve un string dependiendo de si se logró hacer la operación
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        Task<string> Desbloquear_Usuario(int UID);

        /// <summary>
        /// Permite cambiar el rol de un usuario
        /// </summary>
        /// <param name="UID"></param>
        /// <returns></returns>
        Task Cambiar_Rol(int UID, Rol rol);

        /// <summary>
        /// Registra usuarios
        /// </summary>
        /// <param name="usuario">El usuario a ingresar al sistema</param>
        /// <returns></returns>
        Task RegistrarUsuario(Usuario usuario);


        /// <summary>
        /// Verificar que el correo ingresado no sea igual a otro ya creado por otro usuario
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        Task<bool> EmailRepetido(string correo);


        /// <summary>
        /// Verificar que el teléfono ingresado no sea igual a otro ya creado por otro usuario
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<bool> PhoneRepetido(string phone);


        /// <summary>
        /// Para el login, encuentra un usuario que tenga el mismo correo y contraseña pasado
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<Usuario> ValidarUsuario(string correo, string password);


        /// <summary>
        /// Buscas un usuario en base a la ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Usuario> BuscarUsuario(int id);


        /// <summary>
        /// Se encripta la contraseña, no es posible desencriptarla
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        string EncriptarSHA256(string password);

    }
}
