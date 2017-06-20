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
import android.widget.ImageView;

import com.facebook.login.LoginManager;
import com.google.android.gms.ads.AdRequest;
import com.google.android.gms.ads.InterstitialAd;
import com.google.android.gms.ads.purchase.*;


public class BlankFragment extends Fragment {
    private static InterstitialAd mInterstitialAd;
    private ImageView showAd;

    private ImageView inapp;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
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
        inapp = (ImageView) getView().findViewById(R.id.buy);
        inapp.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Model model = Model.Companion.getInstance(getActivity().getApplicationContext());
                Log.d("Model",model.getSecondname());
                ((UnityPlayerActivity)getActivity()).changeActivity();
            }
        });
        showAd = (ImageView) getView().findViewById(R.id.logout);
        showAd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                LoginManager.getInstance().logOut();
            }
        });
    }

}
