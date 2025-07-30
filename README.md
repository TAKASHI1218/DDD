# DDD Sample Application

## 概要
このプロジェクトは、ドメイン駆動開発（DDD）およびテスト駆動開発（TDD）を学ぶために作成されたWindowsアプリケーションです。
特定の学習講座で提供されたコードをベースに構成を理解し、動作確認や改修を通じてドメイン設計・テスト手法の理解を深めました。
教材コードに対して、独自にコメントを追加し、構成の理解を深める目的で再構築・補足を行いました。  
今後は応用・発展に向けて、設計改善や機能追加も検討しています。

## プロジェクト構成と依存関係

| プロジェクト名       | 役割                     | 依存関係                         |
|----------------------|--------------------------|----------------------------------|
| `DDD.Domain`         | ドメインモデル            | なし                             |
| `DDD.Infrastructure` | DB操作や外部依存の抽象化 | `DDD.Domain`                    |
| `DDD.WinForm`        | UI（Windowsフォーム）     | `DDD.Domain`, `DDD.Infrastructure` |
| `DDDTest.Tests`      | 単体テスト               | 上記すべて                       |

## 使用技術

- **フレームワーク**：.NET 8  
- **言語**：C# 12  
- **データベース**：SQLite（System.Data.SQLite）  
- **テストツール**：Moq, ChainingAssertion  

## 起動手順

1. このリポジトリをクローンする  
2. SQLiteクライアントをインストール
   ・推奨ツール：DB Browser for SQLite
3. SQL フォルダにある以下のファイルをSQLiteで順に実行して初期テーブルとデータを作成する
　・Areas.sql
　・Weather.sql
4. Visual Studio 2022/2023 でソリューションを開き、DDD.WinForm プロジェクトを起動
