using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UI;

public class CodeInputManager : MonoBehaviour
{
    public InputField codeInput;
    public int doorId;  // 関連するドアのID

    private string connectionString = "server=localhost;user=root;database=escapeapp;password=yourpassword;";

    public void CheckCode()
    {
        string inputCode = codeInput.text;

        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT is_solved FROM codes WHERE correct_code = @code AND door_id = @doorId";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@code", inputCode);
                cmd.Parameters.AddWithValue("@doorId", doorId);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    // 正しいコードが入力されたらドアを開ける処理
                    Debug.Log("正解！ドアが開いた！");
                    // ドア開閉スクリプトを呼び出す（別スクリプトで管理）
                }
                else
                {
                    Debug.Log("コードが違う！");
                }
            }
        }
    }
}
