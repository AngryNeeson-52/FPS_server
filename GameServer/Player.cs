using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace GameServer
{
    class Player
    {
        public int id;
        public string username;

        public Vector3 position;
        public Quaternion rotation;

        public int hp;
        public int max_hp = 100;

        public Player(int _id, string _username, Vector3 _spawnPosition, int _hp)
        {
            id = _id;
            username = _username;
            position = _spawnPosition;
            rotation = Quaternion.Identity;
            hp = _hp;
        }

        public void Update()
        {
            ServerSend.PlayerPosition(this);
            ServerSend.PlayerRotation(this);
        }

        public void SetPosition(Vector3 _position)
        {
            position = _position;
        }
        public void SetRotation(Quaternion _rotation)
        {
            rotation = _rotation;
        }
        public void SetHp()
        {
            hp = hp - 5;
            ServerSend.PlayerHP(this);
        }
        public void Respawn()
        {
            hp = max_hp;
            ServerSend.PlayerRespawn(this);
        }

        public void Fire()
        {
            ServerSend.PlayerFire(this);
        }
    }
}
