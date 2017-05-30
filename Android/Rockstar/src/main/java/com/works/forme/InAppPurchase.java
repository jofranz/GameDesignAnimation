package com.works.forme;

import android.app.PendingIntent;
import android.app.Service;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.content.IntentSender;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.app.Activity;
import android.os.IBinder;
import android.os.RemoteException;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import com.android.vending.billing.IInAppBillingService;

import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

public class InAppPurchase extends Activity {

    IInAppBillingService mService;
    //view
    private Button buy;
    private TextView show;
    private String productID = "blue_hat";
    private String tag;
    private String mPrice;


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
        tag = "InAppPurchase";
        final boolean blnBind = bindService(new Intent(
                        "com.android.vending.billing.InAppBillingService.BIND"),
                mServiceConn, Context.BIND_AUTO_CREATE);
        buy = (Button) findViewById(R.id.buy);
        show = (TextView) findViewById(R.id.show);

        buy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!blnBind) return;
                if (mService == null) return;

                ArrayList<String> skuList = new ArrayList<String>();
                skuList.add(productID);
                Bundle querySkus = new Bundle();
                querySkus.putStringArrayList("ITEM_ID_LIST", skuList);

                Bundle skuDetails;
                try {
                    skuDetails = mService.getSkuDetails(3, getPackageName(), "inapp", querySkus);
                    Log.i(tag, "getSkuDetails() - success return Bundle");

                } catch (RemoteException e) {
                    e.printStackTrace();
                    Log.d(tag, "getSkuDetails() - fail!");
                    return;
                }

                int response = skuDetails.getInt("RESPONSE_CODE");
                ArrayList<String> responseList
                        = skuDetails.getStringArrayList("DETAILS_LIST");
                if (responseList.size() == 0) return;

                for (String thisResponse : responseList) {
                    try {
                        JSONObject object = new JSONObject(thisResponse);
                        String sku = object.getString("productId");
                        String price = object.getString("price");
                        if (sku.equals("blue_hat"))
                            mPrice = price;

                    } catch (JSONException e) {
                        Log.d(tag, "JSONObject() - failed");
                    }
                }
                Bundle buyIntentBundle = null;
                try {
                    buyIntentBundle = mService.getBuyIntent(3, getPackageName(), productID, "inapp", "testbuy");
                } catch (RemoteException e) {
                    e.printStackTrace();
                }
                Log.d(tag, "getBuyIntent() - success return Bundle");
                response = buyIntentBundle.getInt("RESPONSE_CODE");

                PendingIntent pendingIntent = buyIntentBundle.getParcelable("BUY_INTENT");
                try {
                    startIntentSenderForResult(pendingIntent.getIntentSender(), 1001, new Intent(), 0, 0, 0);
                } catch (IntentSender.SendIntentException e) {
                    e.printStackTrace();
                }


            }
        });
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
        if (mService != null)
            unbindService(mServiceConn);

        super.onDestroy();
    }
}
