# DeserializeTime

Unityでいろいろなフォーマットのデシリアライズ速度を計測してみた
http://qiita.com/Marimoiro/items/e998584d973baab3aac8
で評価で使ったコードですご自由にお使いください

利用したライブラリは以下の通りです。

| 方法 |Simpleデシリアライズ|Nestデシリアライズ|Simpleシリアライズ|Nestシリアライズ|
|:-----------|:------------:|:------------:|:------------:|:------------:|
|Resources.Load|32|31|-|-|
|JsonUtility|15|32|0|16|
|JsonFx|1188|3125|500|1062|
|YamlDotNet|2766|4250|2438|3812|
|XmlSerializer|1109|2813|578|1406|
