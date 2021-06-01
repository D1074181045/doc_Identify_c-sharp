from PIL import Image, ImageEnhance
import pytesseract
from cv2 import cv2


def Img_Pretreatment(img_path, opt):
    img = cv2.imread(img_path, 0)  # 以灰度模式打开图片生成图片对象

    if opt == 1:  # 中值虚化处理
        blurMedian = cv2.medianBlur(img, 3)
        return blurMedian
    elif opt == 2:  # 高斯虚化处理
        blurGaussian = cv2.GaussianBlur(img, (5, 5), 0)
        return blurGaussian
    elif opt == 3:  # 最直接的阙值处理
        simpleThreshold = cv2.threshold(img, 127, 255, cv2.THRESH_BINARY)[1]
        return simpleThreshold
    elif opt == 4:  # 中值自适应阙值处理
        adaptiveThreshold1 = cv2.adaptiveThreshold(img, 255, cv2.ADAPTIVE_THRESH_MEAN_C, cv2.THRESH_BINARY, 11, 2)
        return adaptiveThreshold1
    elif opt == 5:  # 高斯自适应阙值处理
        adaptiveThreshold2 = cv2.adaptiveThreshold(img, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 11, 2)
        return adaptiveThreshold2
    elif opt == 6:  # OTSU二值化处理
        otsuThreshold1 = cv2.threshold(img, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)[1]
        return otsuThreshold1
    elif opt == 7:  # 先高斯虚化过滤后，再做OTSU二值化处理
        blurGaussian = cv2.GaussianBlur(img, (5, 5), 0)
        otsuThreshold2 = cv2.threshold(blurGaussian, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)[1]
        return otsuThreshold2
    else:
        return img


def OCR(image):
    pytesseract.pytesseract.tesseract_cmd = "C:/Program Files/Tesseract-OCR/tesseract.exe"

    # text = pytesseract.image_to_string(img, \
    #             config='--psm 10 --oem 3 -c tessedit_char_whitelist=.ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz:0123456789')
    # text = pytesseract.image_to_string(img,lang='eng',config='--psm 10 digits')

    text = pytesseract.image_to_string(image)

    return text
