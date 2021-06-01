from cv2 import cv2
import OCR
import pytesseract


def Img_Pretreatment(img_path, opt):
    
    img = cv2.imread(img_path, 0)	# 以灰度模式打开图片生成图片对象

    # 先列出用到的预处理手段：
    if (opt == 1):	# 中值虚化处理
        blurMedian = cv2.medianBlur(img, 3)
        return blurMedian
    elif (opt == 2): # 高斯虚化处理
        blurGaussian = cv2.GaussianBlur(img, (5, 5), 0)
        return blurGaussian
    elif (opt == 3): # 最直接的阙值处理
        simpleThreshold = cv2.threshold(img, 127, 255, cv2.THRESH_BINARY)[1]
        return simpleThreshold
    elif (opt == 4): # 中值自适应阙值处理
        adaptiveThreshold1 = cv2.adaptiveThreshold(img, 255, cv2.ADAPTIVE_THRESH_MEAN_C, cv2.THRESH_BINARY, 11, 2)
        return adaptiveThreshold1
    elif (opt == 5):# 高斯自适应阙值处理
        adaptiveThreshold2 = cv2.adaptiveThreshold(img, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 11, 2)
        return adaptiveThreshold2
    elif (opt == 6): # OTSU二值化处理
        otsuThreshold1 = cv2.threshold(img, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)[1]
        return otsuThreshold1 
    elif (opt == 7): # 先高斯虚化过滤后，再做OTSU二值化处理
        blurGaussian = cv2.GaussianBlur(img, (5, 5), 0)
        otsuThreshold2 = cv2.threshold(blurGaussian, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)[1]
        return otsuThreshold2
    # 先列出用到的预处理手段：

    # 虚化处理
    # blurMedian = cv2.medianBlur(img, 3)	# 中值虚化处理
    # blurGaussian = cv2.GaussianBlur(img,(5,5),0)	# 高斯虚化处理

    # 阙值处理

    # 最直接的阙值处理
    # simpleThreshold = cv2.threshold(img, 127, 255, cv2.THRESH_BINARY)[1]
    # # 规定一个阙值127，小于的是背景，大于的是文字(255)。cv2.THRESH_BINARY位置还有其他参数可控选择，参见opencv-python的技术文档。返回一个列表，列表有两个元素，第二个元素是处理的图片对象，所以索引用1

    # # 中值自适应阙值处理
    # adaptiveThreshold1 = cv2.adaptiveThreshold(img, 255, cv2.ADAPTIVE_THRESH_MEAN_C, cv2.THRESH_BINARY, 11, 2)
    # # cv2.ADAPTIVE_THRESH_MEAN_C，阙值取邻近区域的中值。返回处理后的图片对象，注意第一个参数图像对象img必须是灰度模式

    # # 高斯自适应阙值处理
    # adaptiveThreshold2 = cv2.adaptiveThreshold(img, 255, cv2.ADAPTIVE_THRESH_GAUSSIAN_C, cv2.THRESH_BINARY, 11, 2)
    # # cv2.ADAPTIVE_THRESH_GAUSSIAN_C阙值是加了权重的邻近区域值的和，而这个权重的计算使用了高斯窗（Gaussian Window）

    # # OTSU二值化处理
    # otsuThreshold1 = cv2.threshold(img, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)[1]

    # # 先高斯虚化过滤后，再做OTSU二值化处理
    # otsuThreshold2 = cv2.threshold(blurGaussian, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)[1]

# 也可以先中值虚化后跟自适应阙值处理组合，先高斯虚化后过滤后再自适应阙值处理，看哪个预处理预处理效果好。接下来把处理手法名称字串加入列表，作为窗口显示的标题。

# titles = ['Original Image', 'Gaussian filtered Image', 'Median blur', 'Global Thresholding(v=127)', 'Adaptive Mean Thresholding', 'Adaptive Gaussian Thresholding', "Otsu's Thresholding", "Otsu's Thresholding after Gaussian filter"]
# # 预处理后显示窗口的窗口标题列表

# images = [img, blurGaussian, blurMedian, simpleThreshold, adaptiveThreshold1, adaptiveThreshold2,otsuThreshold1, otsuThreshold2]
# # 预处理后的图片对象

# for i in range(len(images)):
#     cv2.imshow(titles[i], images[i])
#     # 显示预处理后的图片，窗口标题从标题列表中取，预处理后的图片对象从对象列表中取
#     cv2.waitKey(0)
#     # 等待敲击键盘结束本次循环，开始下一次循环。注意对敲键盘有反应必须在图片窗口是前端的情况下（前段窗口标题背景为蓝，后段窗口标题背景为灰色）

# pytesseract.pytesseract.tesseract_cmd = "C:/Program Files/Tesseract-OCR/tesseract.exe"

# text = pytesseract.image_to_string(otsuThreshold2, \
#             config='--psm 10 --oem 3 -c tessedit_char_whitelist=.ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz:0123456789')

# text = pytesseract.image_to_string(img)

# print(text)