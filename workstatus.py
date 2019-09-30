import requests
from bs4 import BeautifulSoup

url = "https://www.dgpa.gov.tw/typh/daily/nds.html"
posturl = "https://workstatus.poyi.tk/GetStatusUpdate.aspx"
#posturl = "https://localhost:44396/GetStatusUpdate.aspx"
r = requests.get(url,headers = {'User-Agent': 'Mozilla/5.0'})
r.encoding = "utf-8"
print(r)
soup = BeautifulSoup(r.text, 'html.parser')
text = soup.select("font[color=\"#000000\"] h2")
# for i in range(text.count):
#     posttext = text.content[i]
#     print(posttext)
posttext = ""
if len(text) == 1:
    posttext = text[0].string
    requests.post(posturl,
                  data={"NoChange": str(posttext)}, headers={'User-Agent': 'PoyiWorkStatusUpdater'})
else:
    for i in range(len(soup.select("tr td[headers='city_Name']"))):
        print(soup.select("td[headers='city_Name'] font")[i])
        print(soup.select("td[headers='StopWorkSchool_Info'] font")[i])
        posttext += soup.select("td[headers='city_Name'] font")[i].string + \
            "+"+soup.select("td[headers='StopWorkSchool_Info'] font")[i].string
        if i != len(soup.select("tr td[headers='city_Name']"))-1:
            posttext += ","
    print(posttext)
    requests.post(posturl,
                  data={"data": posttext}, verify=False, headers={'User-Agent': 'PoyiWorkStatusUpdater'})

url = "https://www.dgpa.gov.tw/typh/daily/ndse.html"
r = requests.get(url,headers = {'User-Agent': 'Mozilla/5.0'})
r.encoding = "utf-8"
print(r)
soup = BeautifulSoup(r.text, 'html.parser')
text = soup.select("font[color=\"#000000\"] h2")
# for i in range(text.count):
#     posttext = text.content[i]
#     print(posttext)
posttext = ""
if len(text) == 1:
    posttext = text[0].string
    requests.post(posturl,
                  data={"NoChange": str(posttext)}, verify=False, headers={'User-Agent': 'PoyiWorkStatusUpdater'})
else:
    for i in range(len(soup.select("tr td[headers='city_Name']"))):
        print(soup.select("td[headers='city_Name'] font")[i])
        print(soup.select("td[headers='StopWorkSchool_Info'] font")[i])
        posttext += soup.select("td[headers='city_Name'] font")[i].string + \
            "+"+soup.select("td[headers='StopWorkSchool_Info'] font")[i].string
        if i != len(soup.select("tr td[headers='city_Name']"))-1:
            posttext += ","
    print(posttext)
    requests.post(posturl,
                  data={"Edata": posttext}, verify=False, headers={'User-Agent': 'PoyiWorkStatusUpdater'})
# r = requests.get(url)
# r.encoding = "utf-8"
# soup = BeautifulSoup(r.text, 'html.parser')
# text = soup.select("font[color=\"#000000\"] h2")
# # for i in range(text.count):
# #     posttext = text.content[i]
# #     print(posttext)
# Eposttext = ""
# if len(text) == 1:
#     Eposttext = text[0].string
#    # requests.post(posturl,
#     #              data={"ENoChange": str(Eposttext)}, verify=False)
# else:
#     Eposttext = "Not ready yet."
#    # requests.post(posturl,
#     #              data={"ENoChange": Eposttext}, verify=False)
