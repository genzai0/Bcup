using UnityEngine;

namespace CompletedAssets
{
	public class Bullet : MonoBehaviour
	{
		// 弾の移動スピード
		public int speed = 10;

		// ゲームオブジェクト生成から削除するまでの時間
		public float lifeTime = 1;

		// 攻撃力
		public int power = 1;

        // hp
        public int bullet_hp = 1;

		void Start ()
		{
			// ローカル座標のY軸方向に移動する
			GetComponent<Rigidbody2D> ().velocity = transform.up.normalized * speed;
		
			// lifeTime秒後に削除
			Destroy (gameObject, lifeTime);
		}

        void OnTriggerEnter2D(Collider2D c)
        {
            // レイヤー名を取得
            string layerName = LayerMask.LayerToName(c.gameObject.layer);

            // レイヤー名がBullet (Player)以外の時は何も行わない
            if (layerName != "Bullet (Player)")
                return;

            // PlayerBulletのTransformを取得
            // Transform playerBulletTransform = c.transform.parent;

            // Bulletコンポーネントを取得
            // Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

            // ヒットポイントを減らす
            bullet_hp = bullet_hp - 1;

            // 弾の削除
            Destroy(c.gameObject);

            // ヒットポイントが0以下であれば
            if (bullet_hp <= 0)
            {
                // スコアコンポーネントを取得してポイントを追加
                // FindObjectOfType<Score>().AddPoint(point);

                // 爆発
                // spaceship.Explosion();

                // エネミーの削除
                Destroy(gameObject);

            }
            //else
            //{
                // Damageトリガーをセット
                // spaceship.GetAnimator().SetTrigger("Damage");

            //}
        }
    }
}