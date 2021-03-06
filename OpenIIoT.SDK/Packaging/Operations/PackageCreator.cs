﻿/*
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀  ▀  ▀      ▀▀
      █
      █      ▄███████▄                                                              ▄████████
      █     ███    ███                                                              ███    ███
      █     ███    ███   ▄█████   ▄██████    █  █▄     ▄█████     ▄████▄     ▄█████ ███    █▀     █████    ▄█████   ▄█████      ██     ██████     █████
      █     ███    ███   ██   ██ ██    ██   ██ ▄██▀    ██   ██   ██    ▀    ██   █  ███          ██  ██   ██   █    ██   ██ ▀███████▄ ██    ██   ██  ██
      █   ▀█████████▀    ██   ██ ██    ▀    ██▐█▀      ██   ██  ▄██        ▄██▄▄    ███         ▄██▄▄█▀  ▄██▄▄      ██   ██     ██  ▀ ██    ██  ▄██▄▄█▀
      █     ███        ▀████████ ██    ▄  ▀▀████     ▀████████ ▀▀██ ███▄  ▀▀██▀▀    ███    █▄  ▀███████ ▀▀██▀▀    ▀████████     ██    ██    ██ ▀███████
      █     ███          ██   ██ ██    ██   ██ ▀██▄    ██   ██   ██    ██   ██   █  ███    ███   ██  ██   ██   █    ██   ██     ██    ██    ██   ██  ██
      █    ▄████▀        ██   █▀ ██████▀    ▀█   ▀█▀   ██   █▀   ██████▀    ███████ ████████▀    ██  ██   ███████   ██   █▀    ▄██▀    ██████    ██  ██
      █
 ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄▄  ▄▄ ▄▄   ▄▄▄▄ ▄▄     ▄▄     ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄ ▄ ▄
 █████████████████████████████████████████████████████████████ ███████████████ ██  ██ ██   ████ ██     ██     ████████████████ █ █
      ▄
      █  Creates Package files.
      █
      █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▀▀▀▀▀▀▀▀▀▀▀ ▀ ▀▀▀     ▀▀               ▀
      █  The GNU Affero General Public License (GNU AGPL)
      █
      █  Copyright (C) 2016-2017 JP Dillingham (jp@dillingham.ws)
      █
      █  This program is free software: you can redistribute it and/or modify
      █  it under the terms of the GNU Affero General Public License as published by
      █  the Free Software Foundation, either version 3 of the License, or
      █  (at your option) any later version.
      █
      █  This program is distributed in the hope that it will be useful,
      █  but WITHOUT ANY WARRANTY; without even the implied warranty of
      █  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
      █  GNU Affero General Public License for more details.
      █
      █  You should have received a copy of the GNU Affero General Public License
      █  along with this program.  If not, see <http://www.gnu.org/licenses/>.
      █
      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀ ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀██
                                                                                                   ██
                                                                                               ▀█▄ ██ ▄█▀
                                                                                                 ▀████▀
                                                                                                   ▀▀                            */

namespace OpenIIoT.SDK.Packaging.Operations
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using Newtonsoft.Json;
    using OpenIIoT.SDK.Common;
    using OpenIIoT.SDK.Packaging.Manifest;

    /// <summary>
    ///     Creates Package files.
    /// </summary>
    public class PackageCreator : PackagingOperation
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="PackageCreator"/> class.
        /// </summary>
        public PackageCreator()
            : base(PackagingOperationType.Package)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///     Creates a Package file with the specified filename from the specified input directory using the specified manifest.
        /// </summary>
        /// <param name="inputDirectory">The directory containing the Package contents.</param>
        /// <param name="manifestFile">The PackageManifest file for the Package.</param>
        /// <param name="packageFile">The filename to which the Package file will be saved.</param>
        /// <param name="overwrite">A value indicating whether the Package file will be overwritten if it exists.</param>
        public void CreatePackage(string inputDirectory, string manifestFile, string packageFile, bool overwrite = false)
        {
            CreatePackage(inputDirectory, manifestFile, packageFile, false, string.Empty, string.Empty, string.Empty, overwrite);
        }

        /// <summary>
        ///     Creates a Package file with the specified filename from the specified input directory using the specified manifest,
        ///     then signs the package using the information provided in the privateKeyFile, passphrase and keybaseUsername parameters.
        /// </summary>
        /// <param name="inputDirectory">The directory containing the Package contents.</param>
        /// <param name="manifestFile">The PackageManifest file for the Package.</param>
        /// <param name="packageFile">The filename to which the Package file will be saved.</param>
        /// <param name="signPackage">Indicates whether the package should be signed.</param>
        /// <param name="privateKey">The ASCII-armored PGP private key.</param>
        /// <param name="passphrase">The passphrase for the private key.</param>
        /// <param name="keybaseUsername">
        ///     The Keybase.io username of the account hosting the PGP public key used for digest verification.
        /// </param>
        /// <param name="overwrite">A value indicating whether the Package file will be overwritten if it exists.</param>
        public void CreatePackage(string inputDirectory, string manifestFile, string packageFile, bool signPackage, string privateKey, string passphrase, string keybaseUsername, bool overwrite = false)
        {
            ArgumentValidator.ValidateInputDirectoryArgument(inputDirectory);
            PackageManifest manifest = ValidateManifestFileArgumentAndRetrieveManifest(manifestFile);
            ArgumentValidator.ValidatePackageFileArgumentForWriting(packageFile, overwrite);

            if (signPackage)
            {
                ArgumentValidator.ValidatePrivateKeyArguments(privateKey, passphrase);

                if (string.IsNullOrEmpty(keybaseUsername))
                {
                    throw new ArgumentException($"The required argument 'keybase username' was not supplied.");
                }

                Info($"Package will be signed using the supplied PGP private key as keybase.io user '{keybaseUsername}'.");
            }

            Exception deferredException = default(Exception);

            Info($"Creating package '{Path.GetFileName(packageFile)}' from directory '{inputDirectory}' using manifest file '{Path.GetFileName(manifestFile)}'...");

            string tempDirectory = Path.Combine(Path.GetTempPath(), GetType().Namespace.Split('.')[0], Guid.NewGuid().ToString());
            string payloadDirectory = Path.Combine(tempDirectory, PackagingConstants.PayloadDirectoryName);
            string payloadArchiveName = Path.Combine(tempDirectory, PackagingConstants.PayloadArchiveName);
            string tempPackageFileName = Path.Combine(tempDirectory, Path.GetFileName(packageFile));

            try
            {
                Verbose($"Creating temporary directory '{tempDirectory}'...");
                Directory.CreateDirectory(tempDirectory);
                Verbose("Directory created.");

                Verbose($"Copying input directory '{inputDirectory}' to '{payloadDirectory}'...");
                Common.Utility.CopyDirectory(new DirectoryInfo(inputDirectory), new DirectoryInfo(payloadDirectory));
                Verbose("Directory copied successfully.");

                Verbose($"Validating manifest '{manifestFile}' and generating SHA512 hashes...");
                ValidateManifestAndGenerateHashes(manifest, payloadDirectory);
                Verbose("Manifest validated and hashes written.");

                Verbose($"Compressing payload into '{payloadArchiveName}'...");
                ZipFile.CreateFromDirectory(payloadDirectory, payloadArchiveName);
                Verbose("Successfully compressed payload.");

                Verbose($"Deleting temporary payload directory '{payloadDirectory}...");
                Directory.Delete(payloadDirectory, true);
                Verbose("Successfully deleted temporary payload directory.");

                Verbose("Updating manifest with SHA512 hash of payload archive...");
                manifest.Checksum = Common.Utility.ComputeFileSHA512Hash(payloadArchiveName);
                Verbose($"Hash computed successfully: {manifest.Checksum}.");

                if (signPackage)
                {
                    manifest = SignManifest(manifest, privateKey, passphrase, keybaseUsername);
                }

                Verbose($"Writing manifest to 'manifest.json' in '{tempDirectory}'...");
                WriteManifest(manifest, tempDirectory);
                Verbose("Manifest written successfully.");

                if (File.Exists(packageFile))
                {
                    File.Delete(packageFile);
                }

                Verbose($"Packaging manifest and payload into '{packageFile}'...");
                ZipFile.CreateFromDirectory(tempDirectory, packageFile);
                Success("Package created successfully.");
            }
            catch (Exception ex)
            {
                deferredException = new Exception($"Error creating Package: {ex.Message}", ex);
            }
            finally
            {
                Verbose("Deleting temporary files...");
                Directory.Delete(tempDirectory, true);
                Verbose("Temporary files deleted successfully.");

                if (deferredException != default(Exception))
                {
                    throw deferredException;
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Compares the specified manifest to the contents of the specified directory and hashes any files that had been
        ///     deferred for hashing in the manifest.
        /// </summary>
        /// <param name="manifest">The manifest for which validation and hash generation is to be performed.</param>
        /// <param name="directory">The directory containing payload files.</param>
        internal void ValidateManifestAndGenerateHashes(PackageManifest manifest, string directory)
        {
            foreach (PackageManifestFile file in manifest.Files)
            {
                // determine the absolute path for the file we need to examine
                string fileToCheck = Path.Combine(directory, file.Source);

                if (!File.Exists(fileToCheck))
                {
                    throw new FileNotFoundException($"The file '{file.Source}' is listed in the manifest but is not found on disk.");
                }

                if (file.Checksum != default(string))
                {
                    file.Checksum = Common.Utility.ComputeFileSHA512Hash(fileToCheck);
                }
            }
        }

        /// <summary>
        ///     Validates the manifestFile argument for
        ///     <see cref="CreatePackage(string, string, string, bool, string, string, string, bool)"/> and, if valid, retrieves
        ///     the <see cref="PackageManifest"/> from the file and returns it.
        /// </summary>
        /// <param name="manifestFile">The value specified for the manifestFile argument.</param>
        /// <returns>The PackageManifest file retrieved from the file specified in the manifestFile argument.</returns>
        /// <exception cref="ArgumentException">Thrown when the manifest file is a default or null string.</exception>
        /// <exception cref="FileNotFoundException">
        ///     Thrown when the manifest file can not be found on the local file system.
        /// </exception>
        /// <exception cref="InvalidDataException">Thrown when the manifest file is empty.</exception>
        /// <exception cref="FileLoadException">Thrown when the manifest file fails to be loaded or deserialized.</exception>
        internal PackageManifest ValidateManifestFileArgumentAndRetrieveManifest(string manifestFile)
        {
            if (string.IsNullOrEmpty(manifestFile))
            {
                throw new ArgumentException("The required argument 'manifest' was not supplied.");
            }

            if (!File.Exists(manifestFile))
            {
                throw new FileNotFoundException($"The specified manifest file '{manifestFile}' could not be found.");
            }

            string manifestContents = File.ReadAllText(manifestFile);

            if (manifestContents.Length == 0)
            {
                throw new InvalidDataException($"The specified manifest file '{manifestFile}' is empty.");
            }

            // fetch and deserialize the PackageManifest from the specified file
            PackageManifest manifest;

            try
            {
                manifest = JsonConvert.DeserializeObject<PackageManifest>(manifestContents);
            }
            catch (Exception ex)
            {
                throw new FileLoadException($"The specified manifest file '{manifestFile}' could not be opened: {ex.Message}");
            }

            return manifest;
        }

        /// <summary>
        ///     Digitally signs the specified manifest, adds the signature to the manifest, and returns it.
        /// </summary>
        /// <param name="manifest">The manifest to sign.</param>
        /// <param name="privateKey">The PGP private key with which to sign the file.</param>
        /// <param name="passphrase">The passphrase for the PGP private key.</param>
        /// <param name="keybaseUsername">
        ///     The Keybase.io username of the account hosting the PGP public key used for digest verification.
        /// </param>
        /// <returns>The signed manifest.</returns>
        private PackageManifest SignManifest(PackageManifest manifest, string privateKey, string passphrase, string keybaseUsername)
        {
            Info("Digitally signing manifest...");

            // insert a signature into the manifest. the signer must be included in the hash to prevent tampering.
            PackageManifestSignature signature = new PackageManifestSignature();
            signature.Issuer = PackagingConstants.KeyIssuer;
            signature.Subject = keybaseUsername;
            manifest.Signature = signature;

            Verbose("Creating SHA512 hash of serialized manifest...");
            string manifestHash = Common.Utility.ComputeSHA512Hash(manifest.ToJson());
            Verbose($"Hash computed successfully: {manifestHash}.");

            byte[] manifestBytes = Encoding.ASCII.GetBytes(manifest.ToJson());
            Verbose("Creating digest...");
            byte[] digestBytes = PGPSignature.Sign(manifestBytes, privateKey, passphrase);
            Verbose("Digest created successfully.");

            Verbose("Adding signature to manifest...");
            manifest.Signature.Digest = Encoding.ASCII.GetString(digestBytes);
            Success("Manifest signed successfully.");

            return manifest;
        }

        /// <summary>
        ///     Serializes the specified manifest to JSON and writes it to a 'manifest.json' file in the specified directory.
        /// </summary>
        /// <param name="manifest">The manifest to serialize and write.</param>
        /// <param name="directory">The directory into which the generated file will be written.</param>
        private void WriteManifest(PackageManifest manifest, string directory)
        {
            string destinationFile = Path.Combine(directory, PackagingConstants.ManifestFilename);
            string contents = manifest.ToJson();

            File.WriteAllText(destinationFile, contents);
        }

        #endregion Private Methods
    }
}