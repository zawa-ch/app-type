
- エンドレスタイピングゲーム
- App_Type ver.2

1|はじめに
	このソフトは出された文字列をタイプし続けるというシンプルなタイピングゲームです
	ver.1のUIを踏襲しつつ新しく一から作り直し、ver.1にない機能を詰め込みました

2|動作環境
	最低限の動作環境
		.NET Framework 4.5.2以降のインストール
	快適な動作には
		Windows10以降のOS
		クロック周波数1GHz以上のCPU
		4GB以上のRAM
	が必要です

3|つかいかた
	上の青色のバーをD&Dでウィンドウを移動できます
	ゲームの開始・終了にも青いバーを使います
	App_Type : ゲームメニュー
	　スタート : ゲームを開始します
	　リセット : ゲームのリセットを行います
	　終了 : アプリケーションを終了します
	統計 : 統計情報の確認ができます
	　総タイプ数 : ゲームでタイプを行った総合のキー数です
	　総有効タイプ数 : タイプを行ったキーのうちミスと判定されていないキーの総数です
	　タイピング精度 : タイプ中のミスではないタイプの割合です
	　総クリア数 : タイプを行った文字列の数です
	　合計スコア : これまでのゲームプレイで獲得したスコアの合計です
	　スコアデータのクリア : 保存されているスコアのデータをすべて削除します
		...実行しますか?をクリックすると何のダイアログもなく削除されます
		元には戻せないので注意してください
	ヘルプ : バージョン情報など
	　ver x.x.x.x : App_Typeのバージョンです
	　このアプリケーションについて : バージョン情報を表示します
	Exit : アプリケーションを終了します

	App_Typeゲームメニューから「スタート」をクリックするとカウントダウンが始まります
	カウントダウンが終わったらゲーム開始です
	文字列が表示されるのでその文字列通りにタイピングを行ってください
	タイピングを行う文字列の下に残り時間があります
	残り時間が0になったら終了です

4|仕様
	KeyBindings.datにキーストロークの情報
	Typetext.txtとTypeKana.txtにタイピング文字列の情報が入っています
	これら3ファイルはゲームに必要なため改変・削除を行わないでください
	この3ファイルが見つからないとゲームの起動ができなくなります
	Lang.xmlにUIの各要素に表示されているテキストの情報を格納しています
	削除されても起動はできますが表示されるテキストは元には戻らないので注意してください
	Settings.xmlにスコアなどのデータを保持しています
	これを削除することでもスコアデータの削除が行なえます

5|ライセンス
	このアプリケーションは修正BSDライセンスに基づいて無償で公開されます

Copyright (c) 2016, zawa-ch.
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
* Redistributions of source code must retain the above copyright notice,
  this list of conditions and the following disclaimer.
* Redistributions in binary form must reproduce the above copyright notice,
  this list of conditions and the following disclaimer in the documentation
  and/or other materials provided with the distribution.
* Neither the name of the zawa-ch. nor the names of its contributors
  may be used to endorse or promote products derived from this software
  without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL zawa-ch. BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


<- Copyright zawa-ch. All rights reserved. 2016 ->
