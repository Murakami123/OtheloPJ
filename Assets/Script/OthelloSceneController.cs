using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OthelloSceneController : MonoBehaviour
{
    private void MainFlow()
    {
        // TODO:先攻後攻決める。
        // とりあえず先行 only で良い。（先攻は黒）

        // 駒の置きあい繰り返し。
        {
            // 駒を置けるマスのチェック。置けるマスは光る。

            // 駒を置く。

            // 相手と手番を変える。

            // 駒を置けなくなったら終了（パス）

            // 相手も "前回" 駒を置けなくなってたら終了
        }

        // 自分と相手の駒の数を比較して、多い方が勝ち。

        // もう1回やるかポップアップ出す。
        ShowRetryPopup(true);
    }


    //------------------------------------------------------------------
    // マスのリスト
    //------------------------------------------------------------------
    [SerializeField] private List<ValueList> columList = new List<ValueList>();
    [Serializable]
    public class ValueList
    {
        public List<OthelloSquare> rowList = new List<OthelloSquare>();
    }

    //------------------------------------------------------------------
    // あああああ
    //------------------------------------------------------------------
    private void CheckCanPutSquares(bool isBlack)
    {

        for (int i = 0; i < columList.Count; i++)
        {
            for (int j = 0; j < columList[i].rowList.Count; j++)
            {
                // 既に駒置かれてたら置けない
                var target = columList[i].rowList[j];
                if (target.state == SquareState.Black || target.state == SquareState.White)
                    continue;

                // 上方向が相手の駒かどうか
                if (0 < (i - 1) && (i - 1) <= columList.Count && 0 < j && j <= columList[i - 1].rowList.Count)
                {
                    var isOkeru = columList[i - 1].rowList[j].state == ((isBlack) ? SquareState.White : SquareState.Black);
                    target.SetSquareType((isOkeru) ? SquareState.Okeru : SquareState.Okenai);
                }



            }
        }
    }

    //------------------------------------------------------------------
    // 駒数比較
    //------------------------------------------------------------------
    // private int GetFieldPieceCount( bool isAlly)
    // {

    // }

    //------------------------------------------------------------------
    // リトライポップアップ
    //------------------------------------------------------------------
    [Header("-----リトライポップアップ------")]
    [SerializeField] GameObject retryPopup;
    // [SerializeField] Button yesButton;
    public void ShowRetryPopup(bool isOpen) => retryPopup.gameObject.SetActive(isOpen);

    //------------------------------------------------------------------
    // シーン変更
    //------------------------------------------------------------------
    public void SceneChange() => SceneManager.LoadScene("OthelloScene");
}
