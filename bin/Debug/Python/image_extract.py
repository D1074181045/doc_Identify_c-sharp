from cv2 import cv2
from PIL import Image as ImagePIL, ImageFont, ImageDraw
import io
import numpy as np
import os
import replace
import OCR


def separate_color_red(img):
    # 顏色提取
    # gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    hsv = cv2.cvtColor(img, cv2.COLOR_BGR2HSV)  # 色彩空間轉換為hsv，便於分離

    # 提取顏色範圍，參考網址 https://blog.csdn.net/u013270326/article/details/80704754
    lower_hsv = np.array([156, 43, 46])  # 提取顏色的低值
    high_hsv = np.array([180, 255, 255])  # 提取顏色的高值

    mask = cv2.inRange(hsv, lowerb=lower_hsv, upperb=high_hsv)  # 二值化處理
    return mask


def show(name, img):
    # 顯示圖片
    cv2.namedWindow(str(name), cv2.WINDOW_NORMAL)
    cv2.resizeWindow(str(name), 800, 2000)  # 改變窗口大小
    cv2.imshow(str(name), img)


# 參考 https://www.stacknoob.com/s/qtEkf3sVi23Vq8SYwWTwQN
def image_segmentation(image, img, out_path, filename):  # 提取邊框
    # 返回輪廓
    contours, hierarchy = cv2.findContours(img, cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)[-2:]
    original = image.copy()
    idx, image_id = [0, 0]
    for cnt in contours:
        idx += 1
        if idx % 2 == 0:
            continue
        else:
            image_id += 1
        x, y, w, h = cv2.boundingRect(cnt)  # 回傳矩形框的座標與長寬
        roi = original[y:y + h, x:x + w]  # 裁剪座標為[y0:y1, x0:x1]

        out_pathd = out_path + filename[:-4] + "_" + str(image_id) + ".png"
        cv2.imwrite(out_pathd, roi)  # 儲存圖片

        # im = ImagePIL.open(out_pathd) # 調整圖片 DPI
        # im.save(out_pathd, dpi=(300, 300))

        Img_Pretreatment = OCR.Img_Pretreatment(out_pathd, 7)
        text = OCR.OCR(Img_Pretreatment).replace("¢", "C").replace("O", "0").replace("S", "5").replace("@", "")

        print(text.encode("utf8").decode("utf8"))

        # os.remove(out_pathd)  # 刪除產生檔
        # cv2.rectangle(im,(x,y),(x+w,y+h),(200,0,0),2)


def main():
    SaveDirectory = os.getcwd()
    load_path = SaveDirectory + "\\Python\\Images\\Img1\\"  # 讀取圖像文件夾
    out_path = SaveDirectory + "\\Python\\Images\\Img2\\"  # 保存圖像文件夾
    for file in os.listdir(load_path):  # 遍歷訪問圖像
        img_path = (load_path + file)
        img = cv2.imread(img_path)  # 讀取圖像
        img = cv2.resize(img, (8000, 4000))  # 調整圖片大小
        img_separate = separate_color_red(img)  # 提取紅色框先
        mediu = cv2.medianBlur(img_separate, 5)  # 中值濾波,過濾除最外層框線以外的線條

        # img_lines = lines(mediu) #直線檢測，補充矩形框線
        image_segmentation(img, mediu, out_path, file)  # ROI 剪取框
        # replace.replace(put_path) #消除多餘紅色框線
        cv2.waitKey(0)
        cv2.destroyAllWindows()


if __name__ == "__main__":
    main()
