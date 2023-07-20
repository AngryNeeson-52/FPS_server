using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;


namespace GameServer
{
    class ServerHandle
    {
        public static void WelcomeReceived(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();
            string _username = _packet.ReadString();

            Console.WriteLine($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient} : {_username}.");
            if (_fromClient != _clientIdCheck)
            {
                Console.WriteLine($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
            }
            Server.clients[_fromClient].SendIntoGame(_username);
        }

        public static void PlayerPosition(int _fromClient, Packet _packet)
        {
            Vector3 _position = _packet.ReadVector3();

            Server.clients[_fromClient].player.SetPosition(_position);
        }
        public static void PlayerRotation(int _fromClient, Packet _packet)
        {
            Quaternion _rotation = _packet.ReadQuaternion();

            Server.clients[_fromClient].player.SetRotation(_rotation);
        }
        public static void PlayerHit(int _fromClient, Packet _packet)
        {
           int _hitid = _packet.ReadInt();

            Server.clients[_hitid].player.SetHp();
        }
        public static void PlayerRespawn(int _fromClient, Packet _packet)
        {
            int _spawnid = _packet.ReadInt();

            Server.clients[_spawnid].player.Respawn();
        }
        public static void PlayerFire(int _fromClient, Packet _packet)
        {
            int _clientIdCheck = _packet.ReadInt();

            Server.clients[_clientIdCheck].player.Fire();
        }
    }
}
