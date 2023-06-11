# DDDSample
 DDDに沿ったC#のWebAPIサンプルです。  
 DDDを採用することにより、拡張性、保守性、テスト容易性などが高まり、システムをより柔軟に拡張できるようになります。

- Controllers: アプリケーションのエンドポイントを管理するクラスを配置します。  
WebAPIのコントローラやDTO (Data Transfer Objects) などをここに配置します。  
- Domain: アプリケーションの中核となるドメインモデルを配置します。  
    - Entities: エンティティを配置します。 
    データベースの1行を表し、行の中で完結するロジックもエンティティに記述します。
    - Repositories: アプリケーションの外部と接続する部分は全てインターフェースにするため、
    インターフェースをRepositoriesに配置します。
        - Parameters ディレクトリには、リポジトリのメソッドに渡されるパラメータオブジェクトが含まれます。  
    - ValueObjects: データベースのカラムをObject化したものを配置します。
    - AppSettings.cs: アプリケーションの設定値を定義します。  
    ※MySQLの接続文字列もここに定義しています。環境に合わせて書き換えてください。
- Infrastructure: ドメイン層と外部リソース (データベース、ファイル、外部APIなど) との間のインターフェースや実装を配置します。  
    - DataAccess: データベースへのアクセスを担当するクラスをここに配置します。  
        - Dummy ディレクトリは、データベースの代わりにダミーデータを使用する場合の実装を格納します。   
    - Factories.cs: データベースの種類やDummyなどのインスタンスを切り替えます。
    - Extentions: Infrastructure内で使用する拡張メソッドです。
- DDDExampleTests: テストコードを配置します。  

---
- MySQLのDockerImageは以下からpullできます（Ubuntu 22.04.2 LTS）  
docker pull yanapri/sample:latest
(httpshttps://hub.docker.com/r/yanapri/sample://hub.docker.com/r/yanapri/sample)
