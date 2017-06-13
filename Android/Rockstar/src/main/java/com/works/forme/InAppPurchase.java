package com.works.forme;

import android.content.ComponentName;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.app.Activity;
import android.os.IBinder;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.android.vending.billing.IInAppBillingService;
import com.works.forme.util.IabHelper;
import com.works.forme.util.IabResult;
import com.works.forme.util.Purchase;

import java.io.File;

public class InAppPurchase extends Activity implements View.OnClickListener {

    IInAppBillingService mService;
    //view
    private Button bottlesBtn,passporBtn,moneyBtn,glovesBtn;
    private TextView show;
    private String tag;
    private String mPrice;
    private Controller contr;

    IabHelper mHelper;
    private String bottles = "bottles";
    private String money = "money";
    private String passport = "passport";
    private String gloves = "gloves";
    IabHelper.OnIabPurchaseFinishedListener mPurchaseFinishedListener
            = new IabHelper.OnIabPurchaseFinishedListener() {
        public void onIabPurchaseFinished(IabResult result,
                                          Purchase purchase)
        {
            if (result.isFailure()) {
                // Handle error
                return;
            }
            else if (purchase.getSku().equals(bottles)) {
                Toast.makeText(getApplicationContext(),"Kauf erfolgreich Flasche",Toast.LENGTH_SHORT).show();
            }
            else if (purchase.getSku().equals(money)) {
                Toast.makeText(getApplicationContext(),"Kauf erfolgreich Money",Toast.LENGTH_SHORT).show();
            }
            else if (purchase.getSku().equals(passport)) {
                Toast.makeText(getApplicationContext(),"Kauf erfolgreich Ausweis",Toast.LENGTH_SHORT).show();
            }
            else if (purchase.getSku().equals(gloves)) {
                Toast.makeText(getApplicationContext(),"Kauf erfolgreiche Handschuhe",Toast.LENGTH_SHORT).show();
            }

        }
    };



    private ServiceConnection mServiceConn = new ServiceConnection() {
        @Override
        public void onServiceConnected(ComponentName name, IBinder service) {
            mService = IInAppBillingService.Stub.asInterface(service);

        }

        @Override
        public void onServiceDisconnected(ComponentName name) {
            mService = null;

        }
    };


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_in_app_purchase);
        contr = new Controller();
        File f = new File("UserBoughtState");
        if (f.exists()) {
            Log.d("File exists", "");
        }
        if(f.exists() && !f.isDirectory()) {
            contr.loadState();
        }
        else {
            Log.d("Save","should save");
            contr.saveState();
        }

        tag = "InAppPurchase";

        //final boolean blnBind = bindService(new Intent(
        //                "com.android.vending.billing.InAppBillingService.BIND"),
        //        mServiceConn, Context.BIND_AUTO_CREATE);
        //Intent intent = new Intent("com.android.vending.billing.InAppBillingService.BIND");
        // This is the key line that fixed everything for me
        // intent.setPackage("com.android.vending");

        //bindService(intent, mServiceConn, Context.BIND_AUTO_CREATE);
        String base64EncodedPublicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAji2pxjkVrewvRe8o1VHyp6hii3YU12/D/p/YrjP3TtkvgnpTjCsihTt3Kho4LmNE46aKP7d8SrFdJ8adsnyeNvkQ4xSr2p+n8sH3WibAUA60bqOSH3S7qVbvgXC2OZlyYYzfdWyQTEYQJQB/iuqqC5oe0ZNw6QkDpkIPRNvtv2nUdPBH+ZO0m0eyV8WFjB/UHEC3YjKoVx6V83YApbaVfrZexiVQBl6D1E2e0TVWM3ZWjqYSzYVj1cXnnxLUmXSznPFNFdj0Ne/un6JMJoPDAoxhy7Ru2km6Qwj5KMzyF6zCRxOlH5H0fjI1r6gWmz9IzlSk48+DnCgmFwgD+iibAwIDAQAB\n";

        // compute your public key and store it in base64EncodedPublicKey
        mHelper = new IabHelper(this, base64EncodedPublicKey);

        mHelper.startSetup(new IabHelper.OnIabSetupFinishedListener() {
            public void onIabSetupFinished(IabResult result) {
                if (!result.isSuccess()) {
                    // Oh no, there was a problem.

                }
                // Hooray, IAB is fully set up!
            }
        });

        bottlesBtn = (Button) findViewById(R.id.bottles);
        passporBtn = (Button) findViewById(R.id.passport);
        moneyBtn = (Button) findViewById(R.id.money);
        glovesBtn = (Button) findViewById(R.id.gloves);

        bottlesBtn.setOnClickListener(this);
        passporBtn.setOnClickListener(this);
        moneyBtn.setOnClickListener(this);
        glovesBtn.setOnClickListener(this);
    }
    public void onClick(View v) {
        Log.d("Test",((Button)v).getText().toString());
       switch (((Button)v).getText().toString()){
           case "Flasche":
               if (contr.checkStateof(0)){
                   Toast.makeText(getApplicationContext(),"You bought this already",Toast.LENGTH_SHORT).show();
                   return;
               }
               try {

                   mHelper.launchPurchaseFlow(this, bottles, 10000,
                           mPurchaseFinishedListener, "mypurchasetoken");
               } catch (IabHelper.IabAsyncInProgressException e) {
                   e.printStackTrace();
               }
               break;
           case "Kleingeld":
               if (contr.checkStateof(1)){
                   Toast.makeText(getApplicationContext(),"You bought this already",Toast.LENGTH_SHORT).show();
                   return;
               }
               try {

                   mHelper.launchPurchaseFlow(this, money, 10001,
                           mPurchaseFinishedListener, "mypurchasetoken");
               } catch (IabHelper.IabAsyncInProgressException e) {
                   e.printStackTrace();
               }
               break;
           case "Ausweis":
               if (contr.checkStateof(2)){
                   Toast.makeText(getApplicationContext(),"You bought this already",Toast.LENGTH_SHORT).show();
                   return;
               }
               try {
                    Log.d("mHelper","called");
                   mHelper.launchPurchaseFlow(this, passport, 10002,
                           mPurchaseFinishedListener, "mypurchasetoken");
               } catch (IabHelper.IabAsyncInProgressException e) {
                   e.printStackTrace();
               }
               break;
           case "Handschuhe":
               if (contr.checkStateof(3)){
                   Toast.makeText(getApplicationContext(),"You bought this already",Toast.LENGTH_SHORT).show();
                   return;
               }
               try {

                   mHelper.launchPurchaseFlow(this, gloves, 10003,
                           mPurchaseFinishedListener, "mypurchasetoken");
               } catch (IabHelper.IabAsyncInProgressException e) {
                   e.printStackTrace();
               }
               break;
            default: {
                return;
            }


       }


    }
    public void buyClick(View view) {
        Log.d("It works","Bitches");

    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        Log.d("Tag",String.valueOf(resultCode));
        switch (requestCode){
            case 1000:
                if (resultCode != RESULT_OK) return;
                int responseCode0 = data.getIntExtra("RESPONSE_CODE",1);
                Log.i(tag, "onActivityResult() - \"RESPONSE_CODE\" return " + String.valueOf(responseCode0));
                contr.setElement(0);
                contr.saveState();
                bottlesBtn.setEnabled(false);
                break;
            case 1001:
                if (resultCode != RESULT_OK) return;
                int responseCode1 = data.getIntExtra("RESPONSE_CODE",1);
                Log.i(tag, "onActivityResult() - \"RESPONSE_CODE\" return " + String.valueOf(responseCode1));
                contr.setElement(0);
                contr.saveState();
                moneyBtn.setEnabled(false);
                break;


            case 1002:
                if (resultCode != RESULT_OK) return;
                int responseCode2 = data.getIntExtra("RESPONSE_CODE",1);
                Log.i(tag, "onActivityResult() - \"RESPONSE_CODE\" return " + String.valueOf(responseCode2));
                contr.setElement(0);
                contr.saveState();
                passporBtn.setEnabled(false);
                break;


            case 1003:
                if (resultCode != RESULT_OK) return;
                int responseCode3 = data.getIntExtra("RESPONSE_CODE",1);
                Log.i(tag, "onActivityResult() - \"RESPONSE_CODE\" return " + String.valueOf(responseCode3));
                contr.setElement(0);
                contr.saveState();
                glovesBtn.setEnabled(false);
                break;

            default:
                return;
        }
    }

    @Override
    protected void onDestroy() {
        if (mHelper != null) try {
            mHelper.dispose();
        } catch (IabHelper.IabAsyncInProgressException e) {
            e.printStackTrace();
        }
        mHelper = null;

        super.onDestroy();
    }

    @Override
    public void onBackPressed(){
            startActivity(new Intent(InAppPurchase.this,UnityPlayerActivity.class));

    }
}


