# replace.py
from PIL import Image
import os


def replace(img_path):  # 红色像素替换为白色
    path = img_path
    for pathd in os.listdir(path):
        path2 = path + pathd
        print(path2)
        img2 = Image.open(path2)
        img2 = img2.convert('RGBA')  # 图像格式转为RGBA
        pixdata = img2.load()
        for y in range(img2.size[1]):
            for x in range(img2.size[0]):
                if pixdata[x, y][0] > 225:  # 红色像素
                    pixdata[x, y] = (255, 255, 255, 255)  # 替换为白色，参数分别为(R,G,B,透明度)
        img2 = img2.convert('RGB')  # 图像格式转为RGB
        print("替换文件", pathd)
        img2.save(path2)

