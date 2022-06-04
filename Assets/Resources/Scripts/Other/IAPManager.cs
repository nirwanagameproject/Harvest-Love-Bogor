using Firebase.Database;
using Firebase.Extensions;
using Firebase.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{
    IStoreController m_StoreController; // The Unity Purchasing system.

    //Your products IDs. They should match the ids of your products in your store.
    public string kelereng16000 = "com.fmfstudio.harvestlovebogor.kelereng16000";
    public GameObject notifpurchased;
    public RawImage rawImageDownload;
    public int amountproduk = 0;

    int m_GoldCount;
    int m_DiamondCount;
    Product product;
    DataSnapshot snapshot;
    public bool task1return;

    static public IAPManager instance;

    void Start()
    {
        instance = this;
        //InitializePurchasing();
        //UpdateUI();
    }

    public void InitializePurchasing(int jumlahproduk, List<string> idproduk)
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Add products that will be purchasable and indicate its type.
        for(int i = 0; i < jumlahproduk;i++)
        {
            Debug.Log("Init "+idproduk[i]);
            builder.AddProduct(idproduk[i], ProductType.Consumable);
        }

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyKelereng(string idproduk)
    {
        firedatabase.instance.notifPanel.gameObject.SetActive(true);
        m_StoreController.InitiatePurchase(idproduk);
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"In-App Purchasing initialize failed: {error}");
        firedatabase.instance.notifPanel.gameObject.SetActive(false);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        //Retrieve the purchased product
        product = args.purchasedProduct;
        StartCoroutine(AddKelereng());

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");
        firedatabase.instance.notifPanel.gameObject.SetActive(false);

        //We return Complete, informing IAP that the processing on our side is done and the transaction can be closed.
        return PurchaseProcessingResult.Complete;
    }

    void TASK1CEKID(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        Debug.Log(args.Snapshot.GetRawJsonValue());
        snapshot = args.Snapshot;
        task1return = true;
        // Do something with the data in args.Snapshot
    }

    public IEnumerator AddKelereng()
    {
        yield return new WaitUntil(() => (product!=null && !task1return));
        //Add the purchased product to the players inventory
        if (product.definition.id.Contains("com.fmfstudio.harvestlovebogor.kelereng"))
        {
            Debug.Log("ID KELERENG" + product.receipt + " - "+product.transactionID);
            
            string[] produknya = product.definition.id.Split('.');
            string produkasli = produknya[3];
            produkasli = Regex.Replace(produkasli, "[0-9]", "");

            //CEK DATA DUIT USER
            FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(firedatabase.instance.currentUsername).Child("currency").Child(produkasli).ValueChanged += TASK1CEKID;
            yield return new WaitUntil(() => task1return);
            task1return = false;
            int myduit = 0;
            Int32.TryParse(snapshot.GetRawJsonValue(), out myduit);
            //CEK DATA SHOP KELERENG
            FirebaseDatabase.DefaultInstance
          .GetReference("shop").Child("currency").Child(produkasli).OrderByChild("id").EqualTo(product.definition.id).ValueChanged += TASK1CEKID;
            yield return new WaitUntil(() => task1return);
            task1return = false;
            foreach (var child in snapshot.Children)
            Int32.TryParse(child.Child("amount").Value.ToString(), out amountproduk);
            Debug.Log("DUIT: "+myduit+" AMOUNT: "+amountproduk);
            //WRITE DATA TO USER
            int duitbaru = myduit + amountproduk;
            Dictionary<string, object> produk = new Dictionary<string, object>();
            produk["/" + produkasli] = duitbaru;
            firedatabase.instance.reference.Child("users").Child(firedatabase.instance.currentUsername).Child("currency").UpdateChildrenAsync(produk);
            //WRITE DATA TX ID
            Dictionary<string, object> transaksi = new Dictionary<string, object>();
            receiptKU json = JsonUtility.FromJson<receiptKU>(product.receipt);
            transaksi["/payload"] = json.Payload;
            transaksi["/produkid"] = product.definition.storeSpecificId;
            transaksi["/store"] = json.Store;
            transaksi["/user"] = firedatabase.instance.currentUsername;
            transaksi["/transactionid"] = product.transactionID;
            transaksi["/time"] = DateTime.Now.ToString("HH:mm:ss dd MMMM yyyy");
            firedatabase.instance.reference.Child("historypurchased").Push().UpdateChildrenAsync(transaksi);

            StartCoroutine(EndPurchase(product.definition.id, "currency",""));
            product = null;
        }
        else if (product.definition.id.Contains("com.fmfstudio.harvestlovebogor."))
        {
            Debug.Log("BELI ITEM");

            string[] produknya = product.definition.id.Split('.');
            string produkasli = produknya[3];
            string produktipe = produknya[4];
            produkasli = Regex.Replace(produkasli, "[0-9]", "");

            //CEK DATA JUMLAH ITEM USER
            FirebaseDatabase.DefaultInstance
          .GetReference("users").Child(firedatabase.instance.currentUsername).Child("inventory").Child(produktipe).Child(produkasli).ValueChanged += TASK1CEKID;
            yield return new WaitUntil(() => task1return);
            task1return = false;
            int myduit = 0;
            Int32.TryParse(snapshot.GetRawJsonValue(), out myduit);
            //CEK DATA SHOP ITEM
            FirebaseDatabase.DefaultInstance
          .GetReference("shop").Child("item").Child(produktipe).OrderByChild("id").EqualTo(product.definition.id).ValueChanged += TASK1CEKID;
            yield return new WaitUntil(() => task1return);
            task1return = false;
            string judulitem = "";
            foreach (var child in snapshot.Children)
            {
                Int32.TryParse(child.Child("amount").Value.ToString(), out amountproduk);
                judulitem = child.Child("judul").Value.ToString();
            }
            Debug.Log("DUIT: " + myduit + " AMOUNT: " + amountproduk);
            //WRITE DATA TO USER
            int duitbaru = myduit + amountproduk;
            Dictionary<string, object> produk = new Dictionary<string, object>();
            produk["/" + produkasli] = duitbaru;
            firedatabase.instance.reference.Child("users").Child(firedatabase.instance.currentUsername).Child("inventory").Child(produktipe).UpdateChildrenAsync(produk);
            //WRITE DATA TX ID
            Dictionary<string, object> transaksi = new Dictionary<string, object>();
            receiptKU json = JsonUtility.FromJson<receiptKU>(product.receipt);
            transaksi["/payload"] = json.Payload;
            transaksi["/produkid"] = product.definition.storeSpecificId;
            transaksi["/store"] = json.Store;
            transaksi["/user"] = firedatabase.instance.currentUsername;
            transaksi["/transactionid"] = product.transactionID;
            transaksi["/time"] = DateTime.Now.ToString("HH:mm:ss dd MMMM yyyy");
            firedatabase.instance.reference.Child("historypurchased").Push().UpdateChildrenAsync(transaksi);

            StartCoroutine(EndPurchase(product.definition.id, "item",judulitem));
            product = null;
        }
    }

    public class receiptKU
    {
        public string Payload;
        public string Store;
        public string TransactionID;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
        firedatabase.instance.notifPanel.gameObject.SetActive(false);
    }

    public System.Collections.IEnumerator EndPurchase(string listproduk, string tipeproduk, string judulitem)
    {
        notifpurchased.transform.Find("BotNotif").Find("NotifTunggu").transform.GetComponent<ChangeLanguage>().ChangedLanguge();
        notifpurchased.transform.Find("BotNotif").Find("ButtonOK").Find("Text").transform.GetComponent<ChangeLanguage>().ChangedLanguge();
        AudioSource audio = GameObject.Find("Clicked").transform.Find("kelereng").GetComponent<AudioSource>();
        audio.Play();
        notifpurchased.SetActive(true);
        StorageReference image = firedatabase.instance.storageReference.Child(listproduk + ".png");
        //Get the download link of file
        image.GetDownloadUrlAsync().ContinueWithOnMainThread(task =>
        {
            if (!task.IsFaulted && !task.IsCanceled)
            {
                StartCoroutine(firedatabase.instance.LoadImage(Convert.ToString(task.Result), notifpurchased.transform.Find("BotNotif").Find("RawImage").transform.GetComponent<RawImage>())); //Fetch file from the link
            }
            else
            {
                Debug.Log(task.Exception);
            }
        });
        yield return new WaitUntil(() => amountproduk>0);
        if(tipeproduk.Equals("currency"))
        notifpurchased.transform.Find("BotNotif").Find("TextAmount").transform.GetComponent<Text>().text = amountproduk.ToString();
        else if(tipeproduk.Equals("item")) notifpurchased.transform.Find("BotNotif").Find("TextAmount").transform.GetComponent<Text>().text = judulitem;
        amountproduk = 0;
        task1return = false;
    }

}
