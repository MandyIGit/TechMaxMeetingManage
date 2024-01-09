using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    internal class PyCode
    {
        internal static string[] codes = new string[]{
"a     :����߹�����",
"ai    :�������������������������������������������",
"an    :�����������������������������������",
"ang   :������",
"ao    :���°����������ð���������������������������",
"ba    :�Ѱ˰ɰͰΰ԰հְӰŰưǰȰʰ̰ϰа���������������",
"bai   :�ٰװܰڰذ۰ݰ�����",
"ban   :���������߰����������������",
"bang  :���������������������",
"bao   :�����������������������������������������������",
"bei   :�������������������������������������������������������",
"ben   :���������������",
"beng  :�ñ����±ı����",
"bi    :�ȱرܱձٱʱڱ۱ϱ˱ƱұǱαɱ̱ͱбѱӱԱֱױ�ذ����ݩ޵�����������������������������������������",
"bian  :��߱������ޱ�������������������������������",
"biao  :�����������������������",
"bie   :�������",
"bin   :������������������������������",
"bing  :������������������������",
"bo    :���������������������������������������������������������",
"bu    :����������������������߲�����������",
"ca    :������",
"cai   :�ɲŲĲ˲Ʋòʲ²ǲȲ�",
"can   :�βвϲӲͲѲ����������",
"cang  :�زֲԲղ�",
"cao   :�ݲ۲ٲڲ��������",
"ce    :��߲�����",
"cen   :��",
"ceng  :���",
"cha   :������������������������������",
"chai  :����٭�����",
"chan  :����������������������������������������������",
"chang :�������������������������������������������������",
"chao  :������������������������",
"che   :����������������",
"chen  :�³��Ƴĳ������������������������������",
"cheng :�ɳ̳Ƴǳг˳ʳųϳȳͳγѳҳ�ة���������������������",
"chi   :�ֳ߳ݳԳ�سٳ��ܳճ׳ڳ۳޳�����ܯ��߳������������������������������",
"chong :����������������",
"chou  :���������������ٱ������",
"chu   :��������������������������������ءۻ�������������������",
"chuai :���������",
"chuan :������������������������",
"chuang:��������������",
"chui  :��������������",
"chun  :��������������ݻ����",
"chuo  :���������",
"ci    :�˴δ̴ŴƴʴĴôǴȴɴ�����������",
"cong  :�ӴԴϴдѴ����������",
"cou   :������",
"cu    :�ִٴ״��������������",
"cuan  :�۴ڴ���ߥ����",
"cui   :�ߴ���ݴ޴�������������",
"cun   :��������",
"cuo   :�����������������������",
"da    :�������������������������",
"dai   :������������������������ܤ߰߾����������",
"dan   :�������������������������������������������������",
"dang  :���������������������",
"dao   :������������������������߶�����",
"de    :�ĵõ��",
"deng  :�ȵƵǵ˵ŵɵ������������",
"di    :�صڵ͵е׵۵ֵεܵݵ̵ϵѵҵӵԵյٵ�ص��ڮ��ۡݶ���������������������",
"dia   :��",
"dian  :������ߵ���������������������������",
"diao  :��������������������",
"die   :����������������ܦ�����������",
"ding  :����������������������������������",
"diu   :����",
"dong  :����������������������������������",
"dou   :��������������������",
"du    :�ȶ��������ɶŶ¶ƶٶ����öĶǶ�ܶ�������������",
"duan  :�϶˶ζ̶Ͷ������",
"dui   :�ԶӶѶ�������",
"dun   :�ֶܶٶ׶ضնڶ۶���������������",
"duo   :����޶߶����������������������",
"e     :�������������������������������ج������ݭ��������������������",
"ei    :��",
"en    :������",
"er    :����������������٦���������",
"fa    :��������������������",
"fan   :����������������������������������ެ����������",
"fang  :���ŷ��÷��ķ·�����������������",
"fei   :�ǷʷɷѷϷηзƷ˷ȷ̷�������������������������������",
"fen   :�ַ۷ܷݷ�׷ҷ߷ӷԷշطٷڷ����������",
"feng  :�����������������ٺۺ��������",
"fou   :���",
"fu    :���������򸺸����������������������������������𸿸��������������������������������������������ۮܽ����ݳ����߻����������������������������������������������",
"ga    :�������������",
"gai   :�ĸøǸŸƸ�ؤ�������",
"gan   :�ɸ˸иҸϸʸθѸ̸͸�������ߦ����������������",
"gang  :�ոָ׸ٸڸ۸ܸԸ������",
"gao   :�߸����ݸ޸���غھ۬޻��������",
"ge    :�����������������������ت������ܪ����������������",
"gen   :����بݢ����",
"geng  :�����������������������",
"gong  :�������������������������������������",
"gou   :��������������������ڸ������������������",
"gu    :�Ĺ̹Źǹʹ˹ɹȹ��͹¹ù�������������ڬ������������������������������������",
"gua   :�ҹιϹйѹ���ڴ�������",
"guai  :�ֹԹ�",
"guan  :�عܹ۹ٹ��߹ڹݹ޹���ݸ������������",
"guang :������������",
"gui   :���������������������������������������",
"gun   :�������������",
"guo   :���������������������������������",
"ha    :����",
"hai   :����������������������",
"han   :����������������������������������������������������������",
"hang  :�������������",
"hao   :�úź��ĺ��ºƺ�����޶����������",
"he    :�ͺϺӺκ˺պɺֺȺغǺ̺кʺѺҺԺ�ڭ�������������������",
"hei   :�ں�",
"hen   :�ܺݺۺ�",
"heng  :����ߺ�޿��",
"hong  :��������������ڧݦޮް����",
"hou   :���������ܩ��������������",
"hu    :��������������������������������������������������������������������������������",
"hua   :��������������������������",
"huai  :������������",
"huan  :�����������û�������������ۨۼ��ߧ������������������",
"huang :�ƻɻĻʻŻȻǻ˻̻ͻλϻл��������������������",
"hui   :��ػһӻԻ�ٻۻֻ�ݻջ׻ڻܻ޻߻����ڶ����ޥ�����������������������",
"hun   :�������ڻ������",
"huo   :����������������޽߫������������",
"ji    :�����������������Ǽ��Ƽ����ʼ����ü����̼����ȼͼļ��������������������������������������������������¼żɼ˽�آؽ����٥��ڵ��ܸ������ު��ߴ����������������������������������������������������������",
"jia   :�ӼҼܼۼ׼мټؼּڼݼμϼѼԼռ�٤ۣ�������������������������������",
"jian  :�������������������轥������������߼�����뽢���������������������������������������������������������������������",
"jiang :������������������������������������������",
"jiao  :�Ͻ̽��ǽнŽ��������ͽ��½ѽ����������ýĽƽȽɽʽ˽�ٮ��ܴ����������������������",
"jie   :��׽�ӽڽ�ؽ���ֽҽ�߽ܽԽսٽ۽ݽ޽������ڦ���������������������",
"jin   :���������񾡽������������������������ݣ��������������������",
"jing  :������������������������������������������������������ݼ����������������",
"jiong :��������",
"jiu   :�;žɾ��þȾƾ������¾ľǾʾ˾̾�����������������",
"ju    :�߾ݾ־پ�۾�޾Ӿ��ؾܾϾоѾҾԾվ׾ھ������ڪ����������������������������������������",
"juan  :���������۲�������������",
"jue   :�����������������������ާ�����������������������",
"jun   :������������������������������",
"ka    :��������������",
"kai   :�������������������������",
"kan   :������������٩ݨ����",
"kang  :��������������������",
"kao   :����������������",
"ke    :�ɿ˿ƿ̿Ϳǿſÿ¿����Ŀȿʿ����������������������������",
"ken   :�Ͽпѿ���",
"keng  :�ӿ��",
"kong  :�׿տؿ�������",
"kou   :�ڿۿٿ���ޢߵ����",
"ku    :���ݿ�޿߿���ܥ����",
"kua   :������٨",
"kuai  :�������ۦ������",
"kuan  :������",
"kuang :�����������ڲڿ������������",
"kui   :����������������������ظ���������������������������",
"kun   :��������������������",
"kuo   :����������",
"la    :�������������������������",
"lai   :���������������������",
"lan   :����������������������������������������",
"lang  :��������������ݹ����������",
"lao   :���������������������������������",
"le    :����������߷����",
"lei   :������������������������ڳ������������",
"leng  :������ܨ�",
"li    :��������������������������������������������������������������������ٳٵ۪����ݰ��޼߿���������������������������������������������������������",
"lia   :��",
"lian  :������������������������������������������������",
"liang :����������������������ܮ�������",
"liao  :������������������������ޤ������������",
"lie   :�������������������������",
"lin   :���������������������������������������������",
"ling  :������������������������������۹����������������������",
"liu   :��������������������������������������",
"long  :��¢��¡������£¤���������������",
"lou   :©¥¦§¨ª�����������������",
"lu    :·��¶��¯������½��³��¼��¬��«­®°±²´µ¸¹º»¾¿����������ߣ�������������������������������������������",
"luan  :��������������������",
"lue   :�����",
"lun   :����������������",
"luo   :�������������������������������������������������",
"m     :߼",
"ma    :��������������������������",
"mai   :������������۽ݤ��",
"man   :����������������áܬ��������������",
"mang  :æâäãåç��������",
"mao   :ëìðòóñèéêíîï��������������������",
"me    :ô��",
"mei   :ûÿ��úùø÷��üõöýþ������ݮ���������������",
"men   :��������������",
"meng  :��������������������ޫ��������������",
"mi    :��������������������������������������������������������",
"mian  :����������������������������",
"miao  :�������������������������������",
"mie   :���������",
"min   :�������������������������������",
"ming  :������������ڤ���������",
"miu   :��",
"mo    :ĥĩģĤ��īĦĪĨĬġĢħĭĮįİ�����������������������",
"mou   :ĳıĲٰ����������",
"mu    :ĶĿľĸĹĻ��ķ��ĴĵĺļĽ�������������",
"n     :��",
"na    :������������������������",
"nai   :����������ؾܵ����",
"nan   :������������������",
"nang  :��߭������",
"nao   :����������ث������������",
"ne    :��ګ",
"nei   :����",
"nen   :����",
"neng  :��",
"ni    :������������������������٣����������������",
"nian  :����ճ������������إ���������",
"niang :��",
"niao  :������������",
"nie   :��������������ؿ����������",
"nin   :��",
"ning  :����š����Ţ���������",
"niu   :ţŤťŦ�����",
"nong  :ũŪŨŧٯ��",
"nou   :��",
"nu    :ŮūŬŭ��������������",
"nuan  :ů",
"nue   :Ű",
"nuo   :ŵŲųŴ�������",
"o     :ŷżŶŸŹźŻŽک�������",
"ou    :ŷżŸŹźŻŽک�����",
"pa    :��������žſ��������",
"pai   :��������������ٽ��",
"pan   :�����������������������������",
"pang  :�����������������",
"pao   :������������������������",
"pei   :�����������������������������",
"pen   :������",
"peng  :����������������������������ܡ�����",
"pi    :��Ƥ��Ƣƣ������������ơƥƦƧƨƩا������ۯ��ܱ��ߨ������������������������",
"pian  :Ƭƫƪƭ������������",
"piao  :ƱƯƮư������������",
"pie   :ƲƳد���",
"pin   :ƷƶƵƴƻƸ���������",
"ping  :ƽ��ƿƾƻƹƺƼ��ٷ�����",
"po    :������������������۶����������",
"pou   :������",
"pu    :���������������������������������������������",
"qi    :��������������������������������������������������������������������������ٹ��ܻ��ݽ����ޭ��������������������������������������������",
"qia   :ǡ��Ǣ����",
"qian  :ǰǧǮǳǩǨǦǱǣǯǴǤǥǪǫǬǭǲǵǶǷǸٻ����ܷ����ݡ�����������������������",
"qiang :ǿǹ��ǽǻǺǼǾ����������������������",
"qiao  :���������ǽ�����������������������ڽ��������������",
"qie   :����������ۧ��������",
"qin   :������������������������������������������",
"qing  :����������������������������������������������",
"qiong :�����������������",
"qiu   :����������������ٴ��������������������������",
"qu    :ȥ��ȡ����������Ȥ����Ȣȣڰ۾ޡ޾��������������������������",
"quan  :ȫȨȦȰȪȩȧȬȭȮȯڹ���������������",
"que   :ȷȴȱȲȳȵȶȸ������",
"qun   :Ⱥȹ��",
"ran   :ȻȼȾȽ������",
"rang  :������ȿ�����",
"rao   :�����������",
"re    :����",
"ren   :���������������������������������",
"reng  :����",
"ri    :��",
"rong  :������������������������������",
"rou   :������������",
"ru    :����������������������޸������������",
"ruan  :������",
"rui   :��������ި����",
"run   :����",
"ruo   :����ټ",
"sa    :������ئ�������",
"sai   :����������",
"san   :��ɢ��ɡ�����",
"sang  :ɣɥɤ�����",
"sao   :ɨɦɧɩܣ����������",
"se    :ɫɪɬ����",
"sen   :ɭ",
"seng  :ɮ",
"sha   :ɳɱɰɶɴɯɲɵɷɼ������������",
"shai  :ɸɹ",
"shan  :ɽ����ɺ����ɻɼɾɿ��������������ڨ۷������������������������",
"shang :�������������������������",
"shao  :����������������������ۿ����������",
"she   :�����������������������������������",
"shen  :��������������������������������ڷ��ݷ����������׫|",
"sheng :��ʤ��ʡ��ʢ��ʣʥ������������",
"shi   :��ʱʮʹ��ʵʽʶ����ʯʲʾ��ʷʦʼʩʿ��ʪ��ʳʧ������ʴʫ��ʰ��ʻʨʬʭʸʺ����������������������ݪ��߱���������������������",
"shou  :�������������������������",
"shu   :����������������������������������������������������������������ˡحٿ������������������",
"shua  :ˢˣ�",
"shuai :˥˧ˤ˦�",
"shuan :˨˩����",
"shuang:˫˪ˬ��",
"shui  :ˮ˭˯˰",
"shun  :˳˱˲˴",
"shuo  :˵˶˷˸����������",
"si    :��˼��˹˿��˾��˽˺˻����������������������������������������",
"song  :����������������ڡݿ����������",
"sou   :����������޴�������������",
"su    :�����������������������������������������",
"suan  :�������",
"sui   :������������������������ݴ��������",
"sun   :������ݥ������",
"suo   :�����������������������������",
"ta    :��������̤��̡̢̣���������������",
"tai   :̨̧̫̬̥̩̦̪̭ۢ޷����������",
"tan   :̸̴̵̶̷̼̹̰̲̮̯̱̳̺̻̽̿̾۰��������",
"tang  :����������������������������������������������",
"tao   :����������������������ػ��������",
"te    :��߯���",
"teng  :����������",
"ti    :������������������������������������������",
"tian  :�������������������������",
"tiao  :����������٬���������������",
"tie   :����������",
"ting  :��ͣͥͦ͢����ͤͧ͡��������������",
"tong  :ͬͨͳͭʹͲͯͰͩͪͫͮͱ١������������",
"tou   :ͷͶ͸͵����",
"tu    :ͼ��ͻ;ͽ͹Ϳ������ͺܢݱ������",
"tuan  :���������",
"tui   :��������������",
"tun   :�������������",
"tuo   :����������������������ر٢��������������������",
"wa    :�������������������",
"wai   :����",
"wan   :������������������������������������ܹ������������",
"wang  :�����������������������������",
"wei   :ΪλίΧάΨ��΢ΰδ��ΣβνιζθκαΥΤηγΡΦΩΫέήεμξο��������ޱ���������������������������������",
"wen   :�����������������������������",
"weng  :��������޳",
"wo    :��������������������ݫ���������",
"wu    :����������������������������������������������������������أ���������������������������������������������",
"xi    :ϵϯ��ϰϸ����ϲϴϳϡϷ϶ϣϢϮ��ϩ��ϤϧϪ������������ϥϦϨϫϬϭϱ������ۭݾ�������������������������������������������������������",
"xia   :��������ϼϹϺϻϽϾϿ�������������������",
"xian  :��������������������������������������������������������ݲ޺����������������������������",
"xiang :����������������������������������������ܼ��������������",
"xiao  :С����ЧЦУ������ФТ������������Х���������������������",
"xie   :ЩдблЭежмЬЪавзйкШЫЮЯги��������ޯߢ����������������",
"xin   :������по����н����ضܰ����",
"xing  :������������������������������������ߩ����",
"xiong :��������������ܺ",
"xiu   :��������������������������������",
"xu    :��������������������������������������ڼ����ޣ�����������������",
"xuan  :ѡ������������ѢѣѤ������������������������������",
"xue   :ѧѪѩѨѥѦ��������",
"xun   :ѵѮѸѶѰѭѲѫѬѯѱѳѴѷ������ަ޹��������������",
"ya    :ѹ��ѽ��ѿ����ѼѺѻѾ�������������������������������",
"yan   :����������������������������������������������������������������������ٲ������۱۳���������������������������������������",
"yang  :�������������������������������������������������",
"yao   :Ҫҩҡ��ҧ��ҫű����ҢңҤҥҦҨزسߺ�����������������������",
"ye    :ҲҵҳҶҺҹҰүұҬҭҮҴҷҸ��������������",
"yi    :һ����������ҽ��������������������������������������������ҼҾҿ������������������������������������������������٫ڱ����ܲ����޲������߽߮������������������������������������������������������������",
"yin   :������ӡ������������������������ط۴��ܧ�������������������",
"ying  :ӦӰӲӪӢӳӭӣӤӥӧӨөӫӬӮӯӱ��۫��ݺ��������������������������",
"yo    :Ӵ�",
"yong  :������ӵӿӼӹӶӷӸӺӻӽӾ��ٸ��ܭ�����������",
"you   :��������������������������������������������٧ݬݯݵ��������������������������",
"yu    :����������������Ԥ��������������������������������������������������������������ԡԢԣԥԦخع��ٶ�����������������������������������������������������������������������������",
"yuan  :ԱԭԲԴԪԶԸԺԵԮ԰ԹԧԨԩԫԬԯԳԷ��ܫܾ������������������",
"yue   :��ԽԼԾԻ��Կ��������������h",
"yun   :������������������������۩ܿ�������������",
"za    :��������զ��",
"zai   :������������������",
"zan   :���������������������",
"zang  :�����������",
"zao   :������������������������������",
"ze    :�������������������������",
"zei   :��",
"zen   :����",
"zeng  :��������������",
"zha   :��ըբա��������գդեէթ��߸������������",
"zhai  :կժխիլծ���",
"zhan  :սչվռհձղմյնշոպջտ�������",
"zhang :��������������������������������۵��������",
"zhao  :����������צ����������گ������",
"zhe   :�����������ㆴ������������ߡ��������������",
"zhen  :���������������������������������������������������������",
"zheng :��������֤����֢֣����������֡ں��������",
"zhi   :֮����ֻ��ֱָֹ֧֯����־ְֲִֵֽ֪��ֳ֦֬��֫��ַ��ֶֺּֿ֥֭֨֩��������������ش��ۤ�������������������������������������������������������������",
"zhong :����������������������ڣ�������",
"zhou  :����������������������������ݧ��������������",
"zhu   :��ע��ס������������פ��ף����������������������������٪ۥ��������������������������������",
"zhua  :ץ",
"zhuai :ק",
"zhuan :תרש׫׬׭�����",
"zhuang:װ״׳ׯײ׮ױ��",
"zhui  :׷׶׵׸׹׺�����",
"zhun  :׼׻���",
"zhuo  :׽��׾׿������������پ��ߪ������������",
"zi    :���������������������������������������������������������������������",
"zong  :����������������������",
"zou   :������������۸����",
"zu    :����������������������",
"zuan  :����߬����",
"zui   :��������ީ",
"zun   :����ߤ����",
"zuo   :����������������������������"};
    }
}
