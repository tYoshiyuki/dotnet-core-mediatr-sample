# dotnet-core-mediatr-sample
MediatR を用いて CQRS を実装するサンプル

## Feature
- .NET Core 3.0
- ASP.NET Core
- MediatR
- DDD

## Note
- ドメインモデルのコードは、下記を参考にさせていただきました。
	- https://github.com/nrslib/BottomUpDDDTheLaterPart

- 以下のような構成を想定しています。

|プロジェクト名|説明|
|:--|:--|
|DotNetCoreMediatrSample.Domain|ドメインモデル|
|DotNetCoreMediatrSample.Infrastructure.InMemory|インメモリリポジトリの実装|
|DotNetCoreMediatrSample.Infrastructure.InMemory.Test|インメモリリポジトリのテスト|
|DotNetCoreMediatrSample.Web|Web API|

