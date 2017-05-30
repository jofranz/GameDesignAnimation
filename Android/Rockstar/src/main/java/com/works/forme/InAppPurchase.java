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

public class InAppPurchase extends Activity {

    IInAppBillingService mService;
    //view
    private Button buy,back;
    private TextView show;
    private String tag;
    private String mPrice;
    private Controller contr;

    IabHelper mHelper;
    private String SKU_SON_GLASSES = "son_glasses";
    IabHelper.OnIabPurchaseFinishedListener mPurchaseFinishedListener
            = new IabHelper.OnIabPurchaseFinishedListener() {
        public void onIabPurchaseFinished(IabResult result,
                                          Purchase purchase)
        {
            if (result.isFailure()) {
                // Handle error
                return;
            }
            else if (purchase.getSku().equals(SKU_SON_GLASSES)) {
                buy.setEnabled(false);
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
        tag = "InAppPurchase";

        //final boolean blnBind = bindService(new Intent(
        //                "com.android.vending.billing.InAppBillingService.BIND"),
        //        mServiceConn, Context.BIND_AUTO_CREATE);
        //Intent intent = new Intent("com.android.vending.billing.InAppBillingService.BIND");
        // This is the key line that fixed everything for me
        // intent.setPackage("com.android.vending");

        //bindService(intent, mServiceConn, Context.BIND_AUTO_CREATE);
        String base64EncodedPublicKey = "Test";

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

        buy = (Button) findViewById(R.id.buy);
        show = (TextView) findViewById(R.id.show);
        back = (Button)findViewById(R.id.back);
        back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                startActivity(new Intent(InAppPurchase.this,UnityPlayerActivity.class));
            }
        });

    }
    public void buyClick(View view) {
        Log.d("It works","Bitches");
        if (contr.checkStateof(0)){
            Toast.makeText(getApplicationContext(),"You bought this already",Toast.LENGTH_SHORT).show();
            return;
        }
        try {
            mHelper.launchPurchaseFlow(this, SKU_SON_GLASSES, 10001,
                    mPurchaseFinishedListener, "mypurchasetoken");
        } catch (IabHelper.IabAsyncInProgressException e) {
            e.printStackTrace();
        }
    }
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        if (requestCode == 1001){
            if (resultCode != RESULT_OK) return;
            int responseCode = data.getIntExtra("RESPONSE_CODE",1);
            Log.i(tag, "onActivityResult() - \"RESPONSE_CODE\" return " + String.valueOf(responseCode));
            show.setText("It works");
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

}
