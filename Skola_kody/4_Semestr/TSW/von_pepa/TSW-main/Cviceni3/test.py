from selenium import webdriver
from selenium.webdriver.common.by import By
import unittest

class Chrometest(unittest.TestCase):
    def setUp(self):
        self.driver = webdriver.Chrome()
    def test_first_recipe(self):
        self.driver.get("http://127.0.0.1:5000/picy")
        text_prvniho = self.driver.find_element(By.XPATH, "//ol/li[1]").text
        self.assertEqual(text_prvniho, "čoky: 123")

    def test_add_pizza(self):
        pizza = f"nazev_pizzy: 123"
        self.driver.get("http://127.0.0.1:5000/nova_pica")
        self.driver.find_element(By.NAME, "nazev").clear()
        self.driver.find_element(By.NAME, "nazev").send_keys("nazev_pizzy")

        self.driver.find_element(By.NAME, "cena").clear()
        self.driver.find_element(By.NAME, "cena").send_keys("123")
        self.driver.find_element(By.TAG_NAME, "button").click()

        self.driver.get("http://127.0.0.1:5000/picy")

        self.assertEqual(self.driver.find_element(By.XPATH, "//ol/li[last()]").text, pizza)
    def test_order(self):
        self.driver.get("http://127.0.0.1:5000/objednej")
        self.driver.find_element(By.NAME, "nazev").clear()
        self.driver.find_element(By.NAME, "nazev").send_keys("čoky")

        self.driver.find_element(By.NAME, "mnozstvi").clear()
        self.driver.find_element(By.NAME, "mnozstvi").send_keys("2")
        self.driver.find_element(By.TAG_NAME, "button").click()
        with open("fakura.txt", "r") as f:
            x = f.read()
        self.assertEqual(x, "Zaplat:246")

    def tearDown(self):
        self.driver.close()
if __name__ == "__main__":
    unittest.main()