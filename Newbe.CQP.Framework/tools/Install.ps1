param($installPath, $toolsPath, $package, $project)

start "http://yks.oschina.io/newbe.cqp.framework/"
start "https://cqp.cc/t/32788"
start "http://shang.qq.com/wpa/qunwpa?idkey=6b2a67364b73c76cd472b5cfaf194ca2bfd817f43abc15a22dd507372b0f7b8a"

$items = @(
	"Newbe.CQP.Framework\ForMain\Autofac.dll",
	"Newbe.CQP.Framework\ForMain\Newbe.CQP.Framework.dll",
	"Newbe.CQP.Framework\ForMain\Newbe.CQP.Framework.PluginLoader.dll",
	"Newbe.CQP.Framework\ForMain\readme.txt",
	"Newbe.CQP.Framework\ForPlugin\Newbe.CQP.Framework.ApiExporter.dll",
	"Newbe.CQP.Framework\ForPlugin\Newbe.CQP.Framework.json",
	"Newbe.CQP.Framework\ForPlugin\readme.txt"
)

$items | foreach {
	$configItem = $project.ProjectItems.Item($_)
	# set 'Build Action' to 'None'
	$buildAction = $configItem.Properties.Item("BuildAction")
	$buildAction.Value = 0
}
