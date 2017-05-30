package com.works.forme;

import android.app.Fragment;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.InterstitialAd;
import com.google.android.gms.ads.purchase.*;


public class BlankFragment extends Fragment {
    private static InterstitialAd mInterstitialAd;
    private Button showAd;
    private Button sendButton;
    private Button inapp;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            mInterstitialAd = new InterstitialAd(getContext());
        }
        mInterstitialAd.setAdUnitId("ca-app-pub-9202887805780186/8991148952");
        mInterstitialAd.loadAd(new AdRequest.Builder().addTestDevice("00B74723240B0E3655D79216720F1ABC").build());
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_overlay, container, false);


    }

    @Override
    public void onResume() {
        super.onResume();
        sendButton = (Button) getView().findViewById(R.id.logOut);
        sendButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String text = "change this";
                ((UnityPlayerActivity)getActivity()).mUnityPlayer.UnitySendMessage("AndroidCommunication","JavaMessageIn",text);
            }
        });
        inapp = (Button)getView().findViewById(R.id.inapp);
        inapp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                ((UnityPlayerActivity)getActivity()).changeActivity();
            }
        });
        showAd = (Button) getView().findViewById(R.id.button);
        showAd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (mInterstitialAd.isLoaded()) {
                    mInterstitialAd.show();
                } else {
                    Log.d("TAG", "The interstitial wasn't loaded yet.");
                }
            }
        });
    }



    public static void showAd(){
        if (mInterstitialAd.isLoaded()) {
            mInterstitialAd.show();
        } else {
            Log.d("TAG", "The interstitial wasn't loaded yet.");
        }
    }


}
