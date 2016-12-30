# EstonianIDCardProvider
KeePass Key Provider to utilize the Estonian national ID card

## Notes
This provider may work with other Smart Cards, but it was designed for and tested with the Estonian national ID card.
Read more about the Estonian national ID card [here](https://open-eid.github.io/).

### Tested configurations
**Configuration \#1**
KeePass 2.34

Windows 10 1607

Estonian national ID card

OMNIKEY 4321 smart card reader

## How it works
The provider will generate a KBFX-file next to the KeePass KDBX-file containing a random generated 128 byte key encrypted using the Estonian national ID card's public key.

To unlock, the provider reads the encrypted key, decrypts it using the ID card's private key and PIN, and then feeds the key to KeePass.

### Why is the KBFX-file needed?
The KBFX-file is needed because one is not able to export the private key from the ID-card. This means one cannot derive a key from any private information unique to the ID-card. An alternative could have been to encrypt a static collection of bytes or encrypt e.g. the ID-card serial number using the private key, but this could potentially allow an attacker to acquire the encrypted bytes from the user by providing the user with the unencrypted collection of bytes and have the user encrypt it.

# Disclaimer
The Estonian government may occasionally update the key pair situated on the ID card. **This will render the ID card unable to decrypt the KBFX-file content!**
